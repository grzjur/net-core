using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
IHostEnvironment env = builder.Environment;
Console.WriteLine($"Environment: {env.EnvironmentName}");

builder.Services.AddTransient<ExampleService>();

builder.Configuration
    .AddIniFile("appsettings.ini", optional: true, reloadOnChange: true)
    .AddIniFile($"appsettings.{env.EnvironmentName}.ini", optional: true, reloadOnChange: true);


using IHost host = builder.Build();

var exampleService = host.Services.GetRequiredService<ExampleService>();
exampleService.DisplayValues();