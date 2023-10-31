using System.Linq;
using EasyTests.Models;
using EasyTests.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace EasyTests.Tests.Services;

public class WeatherForecastServiceTests
{
    private readonly Mock<IWeatherSummariesService> _weatherSummariesServiceMock = new Mock<IWeatherSummariesService>();
    private readonly WeatherForecastService _testClass;

    public WeatherForecastServiceTests()
    {
        _weatherSummariesServiceMock
            .Setup(x => x.GetWeatherSummaryDescription(It.IsAny<WeatherPrediction>()))
            .Returns("A string describing the weather")
            .Verifiable();
        _testClass = new WeatherForecastService(_weatherSummariesServiceMock.Object);
    }
    
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
        response.Max(x => x.WeatherPrediction.TemperatureC).Should().BeInRange(-20, 55);
    }
    
    [Fact]
    public void GetWeatherForecast_None_GetSummariesCalledOnce()
    {
        // arrange
        
        // act
        var response = _testClass.GetWeatherForecast();
        
        // assert
        _weatherSummariesServiceMock.Verify(x => x.GetWeatherSummaryDescription(It.IsAny<WeatherPrediction>()), Times.Exactly(5));
    }
}