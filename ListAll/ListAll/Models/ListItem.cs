using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ListAll.Models
{
    public class ListItem : AutoHistory
	{
        [Display(Name = "List")]
        public int ListId { get; set; }

        [ForeignKey(nameof(ListId))]
        public List List { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
