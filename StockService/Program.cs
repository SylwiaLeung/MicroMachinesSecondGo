using Microsoft.EntityFrameworkCore;
using StockService.Data;
using StockService.Services;
using StockService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddDbContext<StockDbContext>(options => options.UseInMemoryDatabase(databaseName: "StockDb"));

var app = builder.Build();

PrepStockDatabase.Initialize();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
