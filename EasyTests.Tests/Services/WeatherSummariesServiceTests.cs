using System;
using EasyTests.Models;
using EasyTests.Services;
using FluentAssertions;
using GenFu;
using Xunit;

namespace EasyTests.Tests.Services;

public class WeatherSummariesServiceTests
{
    private readonly WeatherSummariesService _testClass = new();

    [Fact]
    public void GetWeatherSummaryDescription_Valid_ReturnsString()
    {
        // arrange
        GenFu.GenFu.Configure<WeatherPrediction>()
            .Fill(x => x.TemperatureC)
            .WithinRange(-20, 55)
            .Fill(x => x.Precipitation)
            .WithinRange(0, 100);
        
        var prediction = A.New<WeatherPrediction>();
        
        // act
        var response = _testClass.GetWeatherSummaryDescription(prediction);
        
        // assert
        response.Should().BeOfType<string>();
    }
    
    [Fact]
    public void GetWeatherSummaryDescription_InvalidPrecipitation_ThrowsException()
    {
        // arrange
        var prediction = new WeatherPrediction
        {
            TemperatureC = 1,
            Precipitation = -10
        };
        
        // act
        var act = () => _testClass.GetWeatherSummaryDescription(prediction);
        
        // assert
        act.Should().Throw<IndexOutOfRangeException>();
    }
    
    [Fact]
    public void GetWeatherSummaryDescription_Valid_ReturnsSpecificString()
    {
        // arrange
        var prediction = new WeatherPrediction
        {
            TemperatureC = 1,
            Precipitation = 2
        };
        
        // act
        var response = _testClass.GetWeatherSummaryDescription(prediction);
        
        // assert
        response.Should().Be("Cold and Misting");
    }
}