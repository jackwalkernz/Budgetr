using System;

namespace Budgetr.Core.Models
{
    public class Expense
    {
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Vendor { get; set; }
    }
}
