using Microsoft.Extensions.Options;

public class ExampleService
{
    private readonly IOptionsMonitor<AppSettings> _options; 

    public ExampleService(IOptionsMonitor<AppSettings> options)
    {
        _options = options;

        options.OnChange(settings =>
         {
             Console.WriteLine("Configuration has changed!");
             DisplayValues();
         });        
    }

    public void DisplayValues()
    {
        var currentOptions = _options.CurrentValue;
        Console.WriteLine($"Enabled={currentOptions.Enabled}");
        Console.WriteLine($"SecretKey={currentOptions.SecretKey}");
        Console.WriteLine($"DefaultConnection={currentOptions.DefaultConnection}");
    }
}
