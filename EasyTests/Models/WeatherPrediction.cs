namespace EasyTests.Models;

public class WeatherPrediction
{
    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
    public int Precipitation { get; set; }
    public DateTime Date { get; set; }
}