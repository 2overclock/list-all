using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ListAll.Models
{
    public abstract class ListItem : IHistoryDates
    {
        public Guid Id { get; set; }

        [Display(Name = "List")]
        public Guid ListId { get; set; }

        [ForeignKey(nameof(ListId))]
        public List List { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime _InsertDate { get; set; }
        public DateTime? _DeleteDate { get; set; }
    }
}
