using Labs.Application.Repositories.Transactions;
using Labs.Application.UseCases.Transactions;
using Labs.Application.UseCases.Transactions.Create;
using Labs.Infrastructure.Repositories.Transactions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI
builder.Services.AddScoped<IGetByIdUseCase, GetByIdUseCase>();
builder.Services.AddScoped<ICreateUseCase, CreateUseCase>();

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddLogging();


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
