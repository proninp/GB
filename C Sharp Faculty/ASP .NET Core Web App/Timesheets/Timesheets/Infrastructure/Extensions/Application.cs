using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.OpenApi.Models;
using Timesheets.Data;
using Timesheets.Data.Abstractions;
using Timesheets.Data.Repositories;
using Timesheets.Domain.Abstractions;
using Timesheets.Domain.Implementations;
using Timesheets.Domain.InterAbstractionsfaces;
using Timesheets.Domain.Services;
using Timesheets.Models.Dto.Auth;

namespace Timesheets.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services)
    {
        services.AddDbContext<TimesheetsDBContext>();

        return services;
    }

    public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtAccessOptions>(configuration.GetSection("Authentication:JwtAccessOptions"));
        var jwtSettings = new JwtOptions();
        configuration.Bind("Authentication:JwtAccessOptions", jwtSettings);

        services.AddTransient<ILoginManager, LoginManager>();
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = jwtSettings.GetTokenValidationParameters();
        });
        
        return services;
    }

    public static IServiceCollection ConfigureDomainManagers(this IServiceCollection services)
    {
        services.AddScoped<ISheetManager, SheetManager>();
        services.AddScoped<IContractRepo, ContractRepo>();
        services.AddScoped<IContractManager, ContractManager>();
        services.AddScoped<IUserManager, UserManager>();
        services.AddScoped<ILoginManager, LoginManager>();

        return services;
    }

    public static IServiceCollection ConfigureRepositoris(this IServiceCollection services)
    {
        services.AddScoped<ISheetRepo, SheetRepo>();
        services.AddScoped<IContractRepo, ContractRepo>();
        services.AddScoped<IUserRepo, UserRepo>();

        return services;
    }

    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Timesheets", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme()
                    {
                        Reference = new OpenApiReference() {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}
