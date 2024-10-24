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