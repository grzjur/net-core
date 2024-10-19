using Microsoft.Extensions.DependencyInjection;

public interface ITransientService{Guid GetGuid();}
public interface IScopedService{Guid GetGuid();}
public interface ISingletonService{Guid GetGuid();}

public class TransientService : ITransientService
{
    private readonly Guid _guid;
    public TransientService()
    {
        _guid = Guid.NewGuid();
        Console.WriteLine($"TransientService created with GUID: {_guid}");
    }
    public Guid GetGuid() => _guid;
}

public class ScopedService : IScopedService
{
    private readonly Guid _guid;
    public ScopedService()
    {
        _guid = Guid.NewGuid();
        Console.WriteLine($"ScopedService created with GUID: {_guid}");
    }
    public Guid GetGuid() => _guid;
}

public class SingletonService : ISingletonService
{
    private readonly Guid _guid;
    public SingletonService()
    {
        _guid = Guid.NewGuid();
        Console.WriteLine($"SingletonService created with GUID: {_guid}");
    }
    public Guid GetGuid() => _guid;
}

public class ExampleClass
{
    private readonly ITransientService _transientService;
    private readonly IScopedService _scopedService;
    private readonly ISingletonService _singletonService;

    public ExampleClass(ITransientService transientService, IScopedService scopedService,ISingletonService singletonService)
    {
        _transientService = transientService;
        _scopedService = scopedService;
        _singletonService = singletonService;
        Console.WriteLine("ExampleClass instance created.");
    }

    public void PrintGuids()
    {
        Console.WriteLine($"Transient: {_transientService.GetGuid()}");
        Console.WriteLine($"Scoped: {_scopedService.GetGuid()}");
        Console.WriteLine($"Singleton: {_singletonService.GetGuid()}");
        Console.WriteLine();
    }
}

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