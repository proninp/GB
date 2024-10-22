using HomeWork02.Data;
using HomeWork02.Data.Implementations;
using HomeWork02.Data.Interfaces;
using HomeWork02.Domain.Services;
using HomeWork02.Domain.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddScoped<IPersonManager, PersonManager>()
    .AddScoped<IPersonRepo, PersonRepo>();

builder.Services.AddDbContext<PersonsDBContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(builder.Configuration["DbConnectionStrings"]);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
