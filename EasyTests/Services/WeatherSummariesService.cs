using EasyTests.Models;

namespace EasyTests.Services;

public interface IWeatherSummariesService
{
    string GetWeatherSummaryDescription(WeatherPrediction prediction);
}

public class WeatherSummariesService : IWeatherSummariesService
{
    public string GetWeatherSummaryDescription(WeatherPrediction prediction)
    {
        var temperatureDescription = prediction.TemperatureC switch
        {
            <= 0 => "Freezing",
            > 0 and <= 20 => "Cold",
            > 20 and <= 25 => "Warm",
            > 25 and <= 35 => "Hot",
            > 35 => "Extremely hot"
        };

        var precipitationDescription = prediction.Precipitation switch
        {
            < 0 => throw new IndexOutOfRangeException(),
            0 => "Dry",
            > 0 and <= 20 => "Misting",
            > 20 and <= 40 => "Drizzling",
            > 40 and <= 60 => "Raining",
            > 60 and <= 80 => "Storming",
            > 80 => "Risk of floods"
        };

        return $"{temperatureDescription} and {precipitationDescription}";
    }
}