using System.Text.Json;

public class ExampleService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ExampleService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<WeatherMeasurement> GetWeatherMeasurementAsync(int id) 
    {
        try
        {
            var client = _httpClientFactory.CreateClient("imgw");
            var response = await client.GetAsync($"/api/data/synop/id/{id}");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var measurement = JsonSerializer.Deserialize<WeatherMeasurement>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return measurement ?? throw new InvalidOperationException("Failed to deserialize WeatherMeasurement");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }    
    }
}