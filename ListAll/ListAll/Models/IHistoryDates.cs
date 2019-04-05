using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListAll.Models
{
    interface IHistoryDates
    {
        DateTime _InsertDate { get; set; }

        DateTime? _DeleteDate { get; set; }
    }
}
