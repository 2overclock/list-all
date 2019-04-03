using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using ListAll.Common;
using ListAll.Data.AutoHistory;
using ListAll.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ListAll.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<List> List { get; set; }

        public DbSet<ListItem> ListItem { get; set; }

        public DbSet<HistoryChanges> HistoryChanges { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetOrAddProperty(Constant._InsertDate, typeof(DateTime));

                // 1. Add the IsDeleted property
                entityType.GetOrAddProperty(Constant._DeleteDate, typeof(DateTime?));

                // 2. Create the query filter
                var parameter = Expression.Parameter(entityType.ClrType);

                // EF.Property<bool>(entity, "_DeleteDate")
                var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(DateTime?));
                var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant(Constant._DeleteDate));

                // EF.Property<bool>(entity, "_DeleteDate") == null
                BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(null));

                // post => EF.Property<bool>(entity, "_DeleteDate") == null
                var lambda = Expression.Lambda(compareExpression, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }

        public override EntityEntry Remove(object entity)
        {
            return base.Remove(entity);
        }

        #region SaveChanges

        public override int SaveChanges()
        {
            OnBeforeSaving();

            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries().Where(item => item.State == EntityState.Modified).ToArray())
            {
                Add(entry.CreateHistoryChanges());
            }

            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues[Constant._DeleteDate] = null;
                        entry.CurrentValues[Constant._InsertDate] = DateTime.Now;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[Constant._DeleteDate] = DateTime.Now;
                        break;
                }
            }
        }

        #endregion
    }
}
