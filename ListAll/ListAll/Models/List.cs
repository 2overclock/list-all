using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ListAll.Models
{
    public class List : IHistoryDates
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public List Parent { get; set; }

        public string Name { get; set; }

		public List<ListItem> ListItems { get; set; }

        public DateTime _InsertDate { get; set; }
        public DateTime? _DeleteDate { get; set; }
    }
}
