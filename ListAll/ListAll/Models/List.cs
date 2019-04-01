using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListAll.Models
{
    public class List : AutoHistory
    {
        public string Name { get; set; }

		public List<ListItem> ListItems { get; set; }
    }
}
