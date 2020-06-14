using System.Collections.Generic;
using Template.Database;
using Template.Models;

namespace Template.Core
{
	public class WeatherForecastService
	{
		private readonly ApplicationDbContext _context;

		public WeatherForecastService(ApplicationDbContext context)
		{
			_context = context;
		}

		public IAsyncEnumerable<WeatherForecast> GetAll()
		{
			return _context.Forecasts.AsAsyncEnumerable();
		}
	}
}