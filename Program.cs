using Microsoft.EntityFrameworkCore;
using OrdersManager.Controllers.Interfaces;
using OrdersManager.Data;
using OrdersManager.Orchestrators;
using OrdersManager.Orchestrators.Interfaces;
using OrdersManager.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("OrdersManagerConnection");
builder.Services.AddDbContext<OrdersManagerDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//configure Dependency Injection
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerOrch, CustomerOrch>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
