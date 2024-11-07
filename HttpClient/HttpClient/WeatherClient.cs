using System.Text.Json;

public class WeatherClient : IWeatherClient
{
    private readonly HttpClient _httpClient;

    public WeatherClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherMeasurement> GetWeatherMeasurementAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/api/data/synop/id/{id}");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var measurement = JsonSerializer.Deserialize<WeatherMeasurement>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return measurement ?? throw new InvalidOperationException("Failed to deserialize WeatherMeasurement");
        } catch (Exception ex)
        {
            throw new Exception($"Error getting weather measurement for id {id}", ex);
        }
    }
}