using Expense.Models;

namespace Expense.Data.Service;

public interface IExpenseService
{
    Task<IEnumerable<MyExpense>> GetAll();

    Task Add(MyExpense expense);

    IQueryable GetChartData();
}