using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
            {
                services.Configure<AppSettings>(context.Configuration.GetSection(nameof(AppSettings)));
                services.AddTransient<ExampleService>();
            })
            .Build();

        var exampleService = host.Services.GetRequiredService<ExampleService>();
        exampleService.DisplayValues();
    }
}
