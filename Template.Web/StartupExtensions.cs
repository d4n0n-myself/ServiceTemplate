using Microsoft.Extensions.DependencyInjection;
using Template.Core;
using Template.Database;

namespace Template.Web
{
	public static class StartupExtensions
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddSingleton<WeatherForecastService>();
		}

		public static void RegisterContext(this IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>();
		}
	}
}