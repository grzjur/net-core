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
