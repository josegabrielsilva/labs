using Labs.Application.Repositories.Transactions;
using Labs.Application.Services.Email;
using Labs.Application.UseCases.Transactions;
using Labs.Infrastructure.Repositories.Transactions;
using Labs.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IEmailService, EmailService>(); 
builder.Services.AddLogging();
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<CreateTransactionCommandHandler>());


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
