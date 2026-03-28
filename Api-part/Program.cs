using EFCore.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<APPContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Configure the HTTP request pipeline.
// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<APPContext>();

var expensiveProductsList = context.Products
                                   .Where(p => p.Price > 100)
                                   .ToList();
Console.WriteLine("Expensive Products:");
foreach (var product in expensiveProductsList)
{
    Console.WriteLine($"- {product.Name}: ${product.Price}");
}


app.Run();

