namespace EasyTests.Models;

public class WeatherSummary
{
    public DateTime Date { get; set; }
    public WeatherPrediction WeatherPrediction { get; set; }
    public string? Summary { get; set; }
}