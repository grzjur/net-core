public class ExampleService
{
    private readonly IWeatherClient _weatherClient;

    public ExampleService(IWeatherClient weatherClient)
    {
        _weatherClient = weatherClient;
    }

    public async Task WriteWeatherAsync(int id) 
    {
        try
        {
            var result = await _weatherClient.GetWeatherMeasurementAsync(id);
            Console.WriteLine($"""
                Weather Information:
                Station: {result.StationName}
                Temperature: {result.Temperature}°C
                Pressure: {result.Pressure} hPa
                Rainfall: {result.Rainfall} mm
                """);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }    
    }
}