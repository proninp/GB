using Microsoft.EntityFrameworkCore;
using Timesheets.Data;
using Timesheets.Infrastructure.Extensions;
using Timesheets.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DbOptions>(builder.Configuration.GetSection(nameof(DbOptions)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDbContext();
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureRepositoris();
builder.Services.ConfigureDomainManagers();
builder.Services.ConfigureSwagger();

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
