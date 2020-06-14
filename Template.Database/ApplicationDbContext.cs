using Microsoft.EntityFrameworkCore;
using Template.Models;
using Template.Models.Entities;

namespace Template.Database
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext()
		{
		}

		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(ConnectionStrings.Current.Value);
			base.OnConfiguring(optionsBuilder);
		}

		public DbSet<WeatherForecast> Forecasts { get; set; }
		public DbSet<Model1> Models1 { get; set; }
		public DbSet<Model2> Models2 { get; set; }
		public DbSet<Model3> Models3 { get; set; }
	}
}