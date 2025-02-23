using Expense.Data.Service;
using Expense.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expense.Controllers;

public class ExpenseController : Controller
{
    private readonly IExpenseService _expenseService;

    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    public async Task<IActionResult> Index()
    {
        var expenses = await _expenseService.GetAll();
        return View(expenses);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MyExpense expense)
    {
        if (ModelState.IsValid)
        {
            await _expenseService.Add(expense);
            return RedirectToAction("Index");
        }

        return View(expense);
    }

    public IActionResult GetChart()
    {
        var data = _expenseService.GetChartData();
        return Json(data);
    }
}