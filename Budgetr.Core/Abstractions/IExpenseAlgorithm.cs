using Budgetr.Core.Models;

using System.Collections.Generic;

namespace Budgetr.Core.Abstractions
{
    public interface IExpenseAlgorithm
    {
        Expense ProcessExpense(Dictionary<string, string> rawData);
    }
}
