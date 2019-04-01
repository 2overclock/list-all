using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListAll.Models
{
    public class List : HistoryPatern
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
