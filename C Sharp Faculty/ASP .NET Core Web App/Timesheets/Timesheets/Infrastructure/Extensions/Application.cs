using Timesheets.Data;
using Timesheets.Data.Abstractions;
using Timesheets.Data.Repositories;
using Timesheets.Domain.Abstractions;
using Timesheets.Domain.Implementations;
using Timesheets.Domain.InterAbstractionsfaces;
using Timesheets.Domain.Services;

namespace Timesheets.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<TimesheetsDBContext>();

        return services;
    }

    public static IServiceCollection AddDomainManagers(this IServiceCollection services)
    {
        services.AddScoped<ISheetManager, SheetManager>();
        services.AddScoped<IContractRepo, ContractRepo>();
        services.AddScoped<IContractManager, ContractManager>();
        services.AddScoped<IUserManager, UserManager>();
        services.AddScoped<ILoginManager, LoginManager>();

        return services;
    }

    public static IServiceCollection AddRepositoris(this IServiceCollection services)
    {
        services.AddScoped<ISheetRepo, SheetRepo>();
        services.AddScoped<IContractRepo, ContractRepo>();
        services.AddScoped<IUserRepo, UserRepo>();

        return services;
    }
}
