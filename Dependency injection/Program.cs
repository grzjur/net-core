using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddTransient<ITransientService, TransientService>();
        services.AddScoped<IScopedService, ScopedService>();
        services.AddSingleton<ISingletonService, SingletonService>();

        services.AddTransient<ExampleClass>();        

        using (var serviceProvider = services.BuildServiceProvider())
        {
            Console.WriteLine("Creating first scope:");
            using (var scope1 = serviceProvider.CreateScope())
            {
                var example1 = scope1.ServiceProvider.GetRequiredService<ExampleClass>();
                Console.WriteLine("First call:");
                example1.PrintGuids();

                var example2 = scope1.ServiceProvider.GetRequiredService<ExampleClass>();
                Console.WriteLine("Second call (same scope):");
                example2.PrintGuids();
            }

            Console.WriteLine("Creating second scope:");
            using (var scope2 = serviceProvider.CreateScope())
            {
                var example3 = scope2.ServiceProvider.GetRequiredService<ExampleClass>();
                Console.WriteLine("Third call (new scope):");
                example3.PrintGuids();
            }
        }
    }
}