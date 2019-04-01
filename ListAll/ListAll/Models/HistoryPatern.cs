using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListAll.Models
{
    public abstract class HistoryPatern
    {
        public DateTime _InsertDate { get; set; } = DateTime.Now;

        public DateTime? _DeleteDate { get; set; }
    }
}
