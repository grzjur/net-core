using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddHttpClient<IWeatherClient, WeatherClient>((services, client) =>
        {
            client.BaseAddress = new Uri("https://danepubliczne.imgw.pl/");
        });

        services.AddTransient<ExampleService>();

        return services;
    }
}