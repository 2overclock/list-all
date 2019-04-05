using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ListAll.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ListAll.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private const string _DeleteDate = "_DeleteDate";
        private const string _InsertDate = "_InsertDate";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<List> List { get; set; }

        public DbSet<ListItem> ListItem { get; set; }

        public DbSet<HistoryChanges> HistoryChanges { get; set; }

        public DbSet<LinkItem> LinkItem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entityTypes = modelBuilder.Model.GetEntityTypes()
                .Where(item => typeof(IHistoryDates).IsAssignableFrom(item.ClrType))
                .Where(item => item.IsOwned());

            foreach (var entityType in entityTypes)
            {
                entityType.GetOrAddProperty(_InsertDate, typeof(DateTime));

                // 1. Add the IsDeleted property
                entityType.GetOrAddProperty(_DeleteDate, typeof(DateTime?));

                // 2. Create the query filter
                var parameter = Expression.Parameter(entityType.ClrType);

                // EF.Property<bool>(entity, "_DeleteDate")
                var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(DateTime?));
                var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant(_DeleteDate));

                // EF.Property<bool>(entity, "_DeleteDate") == null
                BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(null));

                // post => EF.Property<bool>(entity, "_DeleteDate") == null
                var lambda = Expression.Lambda(compareExpression, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        private void OnBeforeSaving()
        {
            var entities = ChangeTracker.Entries<IHistoryDates>();

            foreach (var entry in entities.Where(item => item.State == EntityState.Modified).ToArray())
            {
                Add(CreateHistoryChanges(entry));
            }

            foreach (var entry in entities)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues[_DeleteDate] = null;
                        entry.CurrentValues[_InsertDate] = DateTime.Now;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[_DeleteDate] = DateTime.Now;
                        break;
                }
            }
        }

        internal HistoryChanges CreateHistoryChanges(EntityEntry entry)
        {
            var history = new HistoryChanges
            {
                TableName = entry.Metadata.Relational().TableName
            };

            var jsonSerializer = new JsonSerializer();

            var json = new JObject();

            var bef = new JObject();
            var aft = new JObject();

            foreach (var prop in entry.Properties)
            {
                if (prop.IsModified)
                {
                    if (prop.OriginalValue != null)
                    {
                        if (prop.OriginalValue != prop.CurrentValue)
                        {
                            bef[prop.Metadata.Name] = JToken.FromObject(prop.OriginalValue, jsonSerializer);
                        }
                        else
                        {
                            var originalValue = entry.GetDatabaseValues().GetValue<object>(prop.Metadata.Name);
                            bef[prop.Metadata.Name] = originalValue != null
                                ? JToken.FromObject(originalValue, jsonSerializer)
                                : JValue.CreateNull();
                        }
                    }
                    else
                    {
                        bef[prop.Metadata.Name] = JValue.CreateNull();
                    }

                    aft[prop.Metadata.Name] = prop.CurrentValue != null
                        ? JToken.FromObject(prop.CurrentValue, jsonSerializer)
                        : JValue.CreateNull();
                }
            }

            json["before"] = bef;
            json["after"] = aft;

            history.RowId = PrimaryKey(entry);
            history.EntityState = EntityState.Modified;
            history.Change = json.ToString(Formatting.None);

            return history;
        }

        private string PrimaryKey(EntityEntry entry)
        {
            var key = entry.Metadata.FindPrimaryKey();

            var values = new List<object>();
            foreach (var property in key.Properties)
            {
                var value = entry.Property(property.Name).CurrentValue;
                if (value != null)
                {
                    values.Add(value);
                }
            }

            return string.Join(",", values);
        }
    }
}
