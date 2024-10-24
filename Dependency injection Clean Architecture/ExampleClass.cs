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
