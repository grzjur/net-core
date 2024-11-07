
public interface IWeatherClient
{
    Task<WeatherMeasurement> GetWeatherMeasurementAsync(int id);
}