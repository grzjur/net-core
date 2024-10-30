using System.Text.Json.Serialization;

public class WeatherMeasurement
{
    [JsonPropertyName("id_stacji")]
    public string StationId { get; set; }

    [JsonPropertyName("stacja")]
    public string StationName { get; set; }

    [JsonPropertyName("data_pomiaru")]
    public string MeasurementDate { get; set; }

    [JsonPropertyName("godzina_pomiaru")]
    public string MeasurementHour { get; set; }

    [JsonPropertyName("temperatura")]
    public string Temperature { get; set; }

    [JsonPropertyName("predkosc_wiatru")]
    public string WindSpeed { get; set; }

    [JsonPropertyName("kierunek_wiatru")]
    public string WindDirection { get; set; }

    [JsonPropertyName("wilgotnosc_wzgledna")]
    public string RelativeHumidity { get; set; }

    [JsonPropertyName("suma_opadu")]
    public string Rainfall { get; set; }

    [JsonPropertyName("cisnienie")]
    public string Pressure { get; set; }
}
