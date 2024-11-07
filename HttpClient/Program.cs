using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services
    .AddPresentation();

using IHost host = builder.Build();

try
{
    var weatherService = host.Services.GetRequiredService<ExampleService>();
    await weatherService.WriteWeatherAsync(12424);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Environment.Exit(1);
}