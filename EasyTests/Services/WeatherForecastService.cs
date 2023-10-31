using EasyTests.Models;

namespace EasyTests.Services;

public interface IWeatherForecastService
{
    IEnumerable<WeatherSummary> GetWeatherForecast();
}

public class WeatherForecastService : IWeatherForecastService
{
    private readonly IWeatherSummariesService _weatherSummariesService;

    public WeatherForecastService(IWeatherSummariesService weatherSummariesService)
    {
        _weatherSummariesService = weatherSummariesService;
    }
    
    public IEnumerable<WeatherSummary> GetWeatherForecast()
    {
        var forecast = Enumerable.Range(1, 5).Select(index => new WeatherSummary
            {
                Date = DateTime.Now.AddDays(index),
                WeatherPrediction = GetWeatherPredictionForDate(DateTime.Now.AddDays(index))
            })
            .ToArray();

        foreach (var weatherSummary in forecast)
        {
            weatherSummary.Summary = _weatherSummariesService.GetWeatherSummaryDescription(weatherSummary.WeatherPrediction);
        }

        return forecast;
    }

    private WeatherPrediction GetWeatherPredictionForDate(DateTime date)
    {
        return new WeatherPrediction
        {
            TemperatureC = Random.Shared.Next(-20, 55),
            Precipitation = Random.Shared.Next(0, 100),
            Date = date
        };
    }
}