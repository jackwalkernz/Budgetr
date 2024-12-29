using Budgetr.Core.Models;

using System.Collections.Generic;

namespace Budgetr.Core.Abstractions
{
    public interface IExpenseService
    {
        List<Expense> GetExpenses(IExpenseAlgorithm expenseAlgorithm, ICategorisationAlgorithm categorisationAlgorithm, IParsingAlgorithm parsingAlgorithm);
    }
}
