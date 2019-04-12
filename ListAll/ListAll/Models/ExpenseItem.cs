using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListAll.Models
{
    public class ExpenseItem : ListItem
    {
        public double Amount { get; set; }

        public DateTime ExpenseDate { get; set; }
    }
}
