using Budgetr.Core.Abstractions;
using Budgetr.Core.Models;

using Serilog;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetr.Core.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ILogger _logger;

        public ExpenseService(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public List<Expense> GetExpenses(IExpenseAlgorithm expenseAlgorithm, ICategorisationAlgorithm categorisationAlgorithm, IParsingAlgorithm parsingAlgorithm)
        {
            _logger.ForContext<ExpenseService>().Debug("Processing expenses using {Algorithm}", expenseAlgorithm.GetType().Name);
            List<Dictionary<string, string>> expenseData = parsingAlgorithm.ParseData();

            _logger.ForContext<ExpenseService>().Debug("Categorising expenses using {Algorithm}", categorisationAlgorithm.GetType().Name);
            List<Dictionary<string, string>> categorisedData = categorisationAlgorithm.CategoriseData(expenseData);

            _logger.ForContext<ExpenseService>().Debug("Processing expenses");
            ConcurrentBag<Expense> expenses = new ConcurrentBag<Expense>();

            Parallel.ForEach(expenseData, data =>
            {
                Expense expense = expenseAlgorithm.ProcessExpense(data);
                expenses.Add(expense);
            });

            _logger.ForContext<ExpenseService>().Debug("Expenses processed");
            return expenses.ToList();
        }
    }
}
