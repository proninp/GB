using HomeWork02.Data.Implementations;
using HomeWork02.Data.Interfaces;
using HomeWork02.Domain.Services;
using HomeWork02.Domain.Services.Abstractions;
using HomeWork02.Utilities;

var builder = WebApplication.CreateBuilder(args);

var persons = PersonLoader.LoadPersons();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddScoped<IPersonManager, PersonManager>()
    .AddSingleton<IPersonRepo, PersonRepo>()
    .AddSingleton(persons);

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
