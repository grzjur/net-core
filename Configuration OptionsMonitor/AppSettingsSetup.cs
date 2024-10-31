using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

public class AppSettingsSetup : IConfigureOptions<AppSettings>
{
    private const string SectionName = "AppSettings";
    private readonly IConfiguration _configuration;

    public AppSettingsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(AppSettings options)
    {
        _configuration
            .GetSection(SectionName)
            .Bind(options);
    }

    public string Name => SectionName;
}
