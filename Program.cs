
//Scope: POST/api/loan/apply, validate input, save to in-memory list, return response
//test postman GET https://localhost:7279/api/loan | GetById | Apply (HttpPost) ->done response 200 OK 

using LoanAPI.Data;
using LoanAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Register DBContext 16|4
builder.Services.AddDbContext<LoanDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Register Service layer
builder.Services.AddScoped<ILoanService, LoanService>();
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


