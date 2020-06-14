using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Core;
using Template.Database;
using Template.Models;

namespace Template.Web
{
	public static class StartupExtensions
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<WeatherForecastService>();
		}

		public static void RegisterContext(this IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>();

			services.AddScoped<DbContext, ApplicationDbContext>();

			using var applicationDbContext = new ApplicationDbContext();
			applicationDbContext.Database.Migrate();
		}

		public static void SetConnectionStrings()
		{
			Startup.Configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();

			ConnectionStrings.Current =
				new ConnectionStrings(Startup.Configuration.GetValue<string>("ConnectionString"));
		}
	}
}