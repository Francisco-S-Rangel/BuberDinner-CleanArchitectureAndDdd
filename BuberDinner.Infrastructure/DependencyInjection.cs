using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Infrastructure.Authentication;
using BuberDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure;

public static class DependencyInjection{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services){

          services.AddSingleton<IJwtTokenGenerator,jwtTokenGenerator>();
          return services;
    }

}
