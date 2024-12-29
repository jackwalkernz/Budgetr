using Budgetr.Core.Abstractions;
using Budgetr.Core.Models;

using System;
using System.Collections.Generic;

namespace Budgetr.Core.Algorithms
{
    public class BNZExpenseAlgorithm : IExpenseAlgorithm
    {
        public BNZExpenseAlgorithm()
        {
        }

        public Expense ProcessExpense(Dictionary<string, string> data)
        {
            string date = data["Date"];
            string amount = data["Amount"];
            string payee = data["Payee"];
            string category = data["Category"];

            return new Expense
            {
                Date = DateTime.Parse(date),
                Amount = decimal.Parse(amount),
                Vendor = payee,
                Category = category
            };
        }
    }
}
