using Expense.Data;
using Expense.Data.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ExpenseDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("ExpenseYoutubeDB"),
        new MySqlServerVersion(new Version(8, 0, 35))
    )
);
builder.Services.AddScoped<IExpenseService, ExpenseService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.Use(async (context, next) =>
{
    context.Response.Headers["Cache-Control"] = "no-cache, must-revalidate";
    await next();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Expense}/{action=Index}/{id?}");

app.Run();