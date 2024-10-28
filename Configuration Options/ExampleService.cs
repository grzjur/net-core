using Microsoft.Extensions.Options;

public class ExampleService
{
    private readonly AppSettings _options;

    public ExampleService(IOptions<AppSettings> options)
    {
        _options = options.Value;
    }

    public void DisplayValues()
    {
        Console.WriteLine($"Enabled={_options.Enabled}");
        Console.WriteLine($"SecretKey={_options.SecretKey}");
        Console.WriteLine($"DefaultConnection={_options.DefaultConnection}");
    }
}
