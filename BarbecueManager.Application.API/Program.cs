using BarbecueManager.Domain.Interfaces;
using BarbecueManager.Infra.Data;
using BarbecueManager.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SqliteConnectionString");

// Add services to the container.

builder.Services.AddSqlite<BarbecueManagerContext>(connectionString);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IBarbecueRepository, BarbecueRepository>();


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
