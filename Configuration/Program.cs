using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
IHostEnvironment env = builder.Environment;
Console.WriteLine($"Environment: {env.EnvironmentName}");

builder.Services.AddTransient<ExampleService>();

using IHost host = builder.Build();

var exampleService = host.Services.GetRequiredService<ExampleService>();
exampleService.DisplayValues();