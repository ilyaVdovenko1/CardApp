
using CardsApp.Client.ApiConnection.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace CardsApp.Client.ApiConnection.Services;

public static class DependencyInjection
{
    public static IApiCardService AddApiCardService(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSingleton<IApiCardService>(new ApiCardService(configuration["BaseUrl"]));
        
        return serviceCollection.BuildServiceProvider().GetService<IApiCardService>()!;
    }
}