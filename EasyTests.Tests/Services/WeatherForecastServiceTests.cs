using System.Linq;
using EasyTests.Services;
using FluentAssertions;
using Xunit;

namespace EasyTests.Tests.Services;

public class WeatherForecastServiceTests
{
    private readonly WeatherForecastService _testClass = new WeatherForecastService();
    
    [Fact]
    public void GetWeatherForecast_None_Returns5()
    {
        // arrange
        
        // act
        var response = _testClass.GetWeatherForecast();
        // assert
        response.Should().HaveCount(5);
    }

    [Fact]
    public void GetWeatherForecast_None_NotNull()
    {
        // arrange
        
        // act
        var response = _testClass.GetWeatherForecast();
        // assert
        response.Should().NotBeNull();
    }
    
    [Fact]
    public void GetWeatherForecast_None_RespectLimits()
    {
        // arrange
        
        // act
        var response = _testClass.GetWeatherForecast();
        // assert
        response.Max(x => x.TemperatureC).Should().BeInRange(-20, 55);
    }
}