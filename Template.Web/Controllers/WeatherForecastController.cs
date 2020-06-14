using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Template.Core;
using Template.Models;

namespace Template.Web.Controllers
{
	[Route("[controller]")]
	public class WeatherForecastController : Controller
	{
		private static readonly string[] Summaries =
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly WeatherForecastService _service;

		public WeatherForecastController(ILogger<WeatherForecastController> logger,
			WeatherForecastService service)
		{
			_logger = logger;
			_service = service;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
				{
					Date = DateTime.Now.AddDays(index),
					TemperatureC = rng.Next(-20, 55),
					Summary = Summaries[rng.Next(Summaries.Length)]
				})
				.ToArray();
		}

		[HttpGet]
		[Route("[controller]/[action]")]
		public IAsyncEnumerable<WeatherForecast> GetAll()
		{
			return _service.GetAll();
		}
	}
}