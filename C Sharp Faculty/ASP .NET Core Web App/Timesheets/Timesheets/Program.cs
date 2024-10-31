using Microsoft.EntityFrameworkCore;
using Timesheets.Data;
using Timesheets.Data.Abstractions;
using Timesheets.Data.Repositories;
using Timesheets.Domain.Abstractions;
using Timesheets.Domain.Implementations;
using Timesheets.Domain.InterAbstractionsfaces;
using Timesheets.Domain.Services;
using Timesheets.Infrastructure;
using Timesheets.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DbOptions>(builder.Configuration.GetSection(nameof(DbOptions)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication(builder.Configuration);

var app = builder.Build();

using var timesheetsDbContext = app.Services.GetRequiredService<TimesheetsDBContext>();
await timesheetsDbContext.Database.MigrateAsync();

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
