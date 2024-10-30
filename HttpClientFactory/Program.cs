using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient("imgw", client =>
{
    client.BaseAddress = new Uri("https://danepubliczne.imgw.pl/");
});

builder.Services.AddTransient<ExampleService>();
using IHost host = builder.Build();

try
{
    var weatherService = host.Services.GetRequiredService<ExampleService>();
    var measurement = await weatherService.GetWeatherMeasurementAsync(12424);
    Console.WriteLine($"""
        Weather Information:
        Station: {measurement.StationName}
        Temperature: {measurement.Temperature}°C
        Pressure: {measurement.Pressure} hPa
        Rainfall: {measurement.Rainfall} mm
        """);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Environment.Exit(1);
}
