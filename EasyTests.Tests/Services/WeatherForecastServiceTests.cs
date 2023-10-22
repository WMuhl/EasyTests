using System;
using System.Collections.Generic;
using System.Linq;
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
            .Setup(x => x.GetWeatherSummaries())
            .Returns(new[] {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"})
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
        response.Max(x => x.TemperatureC).Should().BeInRange(-20, 55);
    }
    
    [Fact]
    public void GetWeatherForecast_None_GetSummariesCalledOnce()
    {
        // arrange
        
        // act
        var response = _testClass.GetWeatherForecast();
        
        // assert
        _weatherSummariesServiceMock.Verify(x => x.GetWeatherSummaries(), Times.Once);
    }
    
    [Fact]
    public void GetWeatherForecast_WeatherSummariesEmpty_ThrowsIndexOutOfRangeException()
    {
        // arrange
        _weatherSummariesServiceMock.Setup(x => x.GetWeatherSummaries())
            .Returns(Array.Empty<string>());
        
        // act
        Func<IEnumerable<WeatherForecast>> action = () => _testClass.GetWeatherForecast();
       
        // assert
        action.Should().Throw<IndexOutOfRangeException>();
    }
}