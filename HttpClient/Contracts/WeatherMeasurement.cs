using System.Text.Json.Serialization;

public class WeatherMeasurement
{
    [JsonPropertyName("id_stacji")]
    public required string StationId { get; set; }

    [JsonPropertyName("stacja")]
    public required string StationName { get; set; }

    [JsonPropertyName("data_pomiaru")]
    public required string MeasurementDate { get; set; }

    [JsonPropertyName("godzina_pomiaru")]
    public required string MeasurementHour { get; set; }

    [JsonPropertyName("temperatura")]
    public required string Temperature { get; set; }

    [JsonPropertyName("predkosc_wiatru")]
    public required string WindSpeed { get; set; }

    [JsonPropertyName("kierunek_wiatru")]
    public required string WindDirection { get; set; }

    [JsonPropertyName("wilgotnosc_wzgledna")]
    public required string RelativeHumidity { get; set; }

    [JsonPropertyName("suma_opadu")]
    public required string Rainfall { get; set; }

    [JsonPropertyName("cisnienie")]
    public required string Pressure { get; set; }
}
