
using CardsApp.Client.ApiConnection.Services;
using CardsApp.Client.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CardsApp.Client.Domain.Services;

public static class DependencyInjection
{
    public static ICardsAppService AddCardsAppService(this ServiceCollection serviceCollection, IConfiguration configuration)
    {
        
        var apiCardService = serviceCollection.AddApiCardService(configuration);
        serviceCollection.AddSingleton<ICardsAppService>(new CardsAppService(apiCardService));

        return serviceCollection.BuildServiceProvider().GetService<ICardsAppService>()!;

    }
}