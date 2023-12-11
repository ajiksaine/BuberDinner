using BuberDinner.Application.Common.Interface.Authentication;
using BuberDinner.Application.Common.Interface.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Infrastructure.Persistence;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDatetimeProvider, DatetimeProvider>();
        services.AddSingleton<IUserRepository, UserRepository>();
        return services;
    }
}