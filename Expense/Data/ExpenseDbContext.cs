using Expense.Models;
using Microsoft.EntityFrameworkCore;

namespace Expense.Data;

public class ExpenseDbContext : DbContext
{
    public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
    {
    }

    //protected ExpenseDbContext()
    //{
    //}

    public DbSet<MyExpense> Expenses { get; set; }
}