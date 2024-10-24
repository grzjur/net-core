using Microsoft.Extensions.Configuration;

public class ExampleService
{
    private readonly IConfiguration _config;

    public ExampleService(IConfiguration config)
    {
        _config = config;
    }

    public void DisplayValues()
    {
        Console.WriteLine($"Enabled={_config.GetSection("AppSettings").GetValue<bool>("Enabled")}");
        Console.WriteLine($"SecretKey={_config.GetSection("AppSettings").GetValue<string>("SecretKey")}");
        Console.WriteLine($"DefaultConnection={_config.GetSection("AppSettings").GetValue<string>("DefaultConnection")}");
    }
}