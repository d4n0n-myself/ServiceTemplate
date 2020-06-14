using System;
using Template.Models.Entities.Base;

namespace Template.Models.Entities
{
	public class WeatherForecast : HaveId
	{
		public DateTime Date { get; set; }
		public int TemperatureC { get; set; }
		public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
		public string Summary { get; set; }
	}
}