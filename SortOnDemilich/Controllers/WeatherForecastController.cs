using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SortOnDemilich.Models;
using SortOnDemilich.Others;

namespace SortOnDemilich.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /*[HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        return Ok(new ResponseApi
        {
            Data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            }),
            Success = ModelState.IsValid,
            Error = ModelState.Values.SelectMany(e => e.Errors)
        });
    }*/
    
    [HttpPost("Random HeapSort")]
    public IActionResult RandomHeap([FromBody]int tamanho)
    {
        var arr = Enumerable.Repeat(0, tamanho).Select(e => Random.Shared.Next(1, 100*2)).ToArray();
        var arr2 = arr.Clone();
        var tempo = HeapSortAlgorithm.HeapSort(arr, tamanho);
        return Ok(new ResponseApi
        {
            Data = new
            {
                analyse = new ResultSortTime
                {
                    Algorithm = "Heap Sort",
                    Length = tamanho,
                    Duration = tempo
                },
                original = arr2,
                sorted = arr
            },
            Success = TryValidateModel(typeof(WeatherForecast))
        });
    }

    [HttpPost("Random BubbleSort")]
    public IActionResult RandomBubble([FromBody]int tamanho)
    {
        var arr = Enumerable.Repeat(0, tamanho).Select(e => Random.Shared.Next(1, tamanho*2)).ToArray();
        var arr2 = arr.Clone();
        var tempo = BubbleSortAlgorithm.BubbleSort(arr);
        return Ok(new ResponseApi
        {
            Data = new
            {
                analyse = new ResultSortTime
                {
                    Algorithm = "Bubble Sort",
                    Length = tamanho,
                    Duration = tempo
                },
                original = arr2,
                sorted = arr
            },
            Success = TryValidateModel(typeof(WeatherForecast))
        });
    }
}