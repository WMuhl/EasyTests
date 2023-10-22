namespace EasyTests.Services;

public interface IWeatherSummariesService
{
    string[] GetWeatherSummaries();
}

public class WeatherSummariesService : IWeatherSummariesService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public string[] GetWeatherSummaries()
    {
        return Summaries;
    }
}