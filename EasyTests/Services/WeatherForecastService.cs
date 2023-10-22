namespace EasyTests.Services;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> GetWeatherForecast();
}

public class WeatherForecastService : IWeatherForecastService
{
    private readonly IWeatherSummariesService _weatherSummariesService;

    public WeatherForecastService(IWeatherSummariesService weatherSummariesService)
    {
        _weatherSummariesService = weatherSummariesService;
    }
    
    public IEnumerable<WeatherForecast> GetWeatherForecast()
    {
        var weatherSummaries = _weatherSummariesService.GetWeatherSummaries();

        if (!weatherSummaries.Any())
            throw new IndexOutOfRangeException();
        
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = weatherSummaries[Random.Shared.Next(weatherSummaries.Length)]
            })
            .ToArray();
    }
}