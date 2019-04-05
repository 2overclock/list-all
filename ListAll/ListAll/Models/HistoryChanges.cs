using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListAll.Models
{
    /// <summary>
    /// Represents the entity change history.
    /// </summary>
    public class HistoryChanges
    {
        /// <summary>
        /// Gets or sets the primary key.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the source row id.
        /// </summary>
        /// <value>The source row id.</value>
        [MaxLength(50)]
        public string RowId { get; set; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        [MaxLength(128)]
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the json about the changing.
        /// </summary>
        /// <value>The json about the changing.</value>
        public string Change { get; set; }

        /// <summary>
        /// Gets or sets the change kind.
        /// </summary>
        /// <value>The change kind.</value>
        public EntityState EntityState { get; set; }

        public DateTime ChangeDate { get; set; } = DateTime.Now;
    }
}
