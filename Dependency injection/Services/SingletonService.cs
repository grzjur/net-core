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
