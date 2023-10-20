using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Interfaces.Services;
using BubberDinner.Infrastructure.Authentication;
using BubberDinner.Infrastructure.Services;
using BuberDinner.Application.Services.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure;

public static class DependencyInjection{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        ConfigurationManager configuration){

          services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
          services.AddSingleton<IJwtTokenGenerator,jwtTokenGenerator>();
          services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
          return services;
    }

}
