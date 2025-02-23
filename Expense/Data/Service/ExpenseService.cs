using Expense.Models;
using Microsoft.EntityFrameworkCore;

namespace Expense.Data.Service;

public class ExpenseService : IExpenseService
{
    private readonly ExpenseDbContext _context;

    public ExpenseService(ExpenseDbContext context)
    {
        _context = context;
    }


    public async Task Add(MyExpense expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<MyExpense>> GetAll()
    {
        var expenses = await _context.Expenses.ToListAsync();
        return expenses;
    }

    public IQueryable GetChartData()
    {
        var data = _context.Expenses.GroupBy(e => e.Category)
            .Select(g => new { Category = g.Key, Total = g.Sum(e => e.Balance) });
        return data;
    }
}