using System.Runtime.CompilerServices;
using Timesheets.Data.Abstractions;
using Timesheets.Data.Repositories;
using Timesheets.Data;
using Timesheets.Domain.Abstractions;
using Timesheets.Domain.Implementations;
using Timesheets.Domain.InterAbstractionsfaces;
using Timesheets.Domain.Services;

namespace Timesheets.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TimesheetsDBContext>();
        services.AddScoped<ISheetRepo, SheetRepo>();
        services.AddScoped<ISheetManager, SheetManager>();
        services.AddScoped<IContractRepo, ContractRepo>();
        services.AddScoped<IContractManager, ContractManager>();

        return services;
    }
}
