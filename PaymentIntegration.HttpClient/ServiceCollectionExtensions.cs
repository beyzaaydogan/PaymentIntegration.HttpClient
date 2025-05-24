using Microsoft.Extensions.DependencyInjection;
using PaymentIntegration.HttpClient;

namespace BalanceManagementApiClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBalanceManagementApiClient(
        this IServiceCollection services, 
        string baseUrl,
        Action<IHttpClientBuilder>? configureClient = null)
    {
        var clientBuilder = services.AddHttpClient<IBalanceManagementApiClient, PaymentIntegration.HttpClient.BalanceManagementApiClient>(client =>
        {
            client.BaseAddress = new Uri(baseUrl);
        });
        configureClient?.Invoke(clientBuilder);
        
        return services;
    }
}
