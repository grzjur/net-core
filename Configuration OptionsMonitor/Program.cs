using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.ConfigureOptions<AppSettingsSetup>();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));

builder.Services.AddTransient<ExampleService>();


using IHost host = builder.Build();

try
{
    var exampleService = host.Services.GetRequiredService<ExampleService>();

    for (int i = 0; i < 20; i++)
    {
        await Task.Delay(1000);
        exampleService.DisplayValues();
    }

}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Environment.Exit(1);
}