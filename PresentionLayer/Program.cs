using BusinessLogicLayer.Service.Interface;
using BusinessLogicLayer.Service;
using DataLayer.Data;
using DataLayer.Repository;
using DataLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// PostgreSQL + EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IGetEmployeesDataAccess, GetEmployeesDataAccess>();
builder.Services.AddScoped<IGetEmployeesBusinessLogic, GetEmployessBussinessLogic>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
