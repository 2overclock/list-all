using ListAll.Data.AutoHistory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListAll.Data
{
    public static class DbContextExtenxions
    {
        internal static HistoryChanges CreateHistoryChanges(this EntityEntry entry)
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

            history.RowId = entry.PrimaryKey();
            history.EntityState = EntityState.Modified;
            history.Changed = json.ToString(Formatting.None);

            return history;
        }

        private static string PrimaryKey(this EntityEntry entry)
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
