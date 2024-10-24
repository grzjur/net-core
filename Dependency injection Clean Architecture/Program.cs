using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);
{
    builder.Services.AddApplication();
}


var app = builder.Build();
{
    Console.WriteLine("Creating first scope:");
    using (var scope1 = app.Services.CreateScope()){
        var example1 = scope1.ServiceProvider.GetRequiredService<ExampleClass>();
        Console.WriteLine("First call:");
        example1.PrintGuids();

        var example2 = scope1.ServiceProvider.GetRequiredService<ExampleClass>();
        Console.WriteLine("Second call (same scope):");
        example2.PrintGuids();
    }

    Console.WriteLine("Creating second scope:");
    using (var scope2 = app.Services.CreateScope()){
        var example3 = scope2.ServiceProvider.GetRequiredService<ExampleClass>();
        Console.WriteLine("Third call (new scope):");
        example3.PrintGuids();
    }
}