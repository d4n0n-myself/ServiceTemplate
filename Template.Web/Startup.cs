using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Template.Web
{
	public class Startup
	{
		public static IConfiguration Configuration { get; set; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			StartupExtensions.SetConnectionStrings();
			services.RegisterContext();
			services.RegisterServices();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "v1",
					Version = "v1"
				});

#pragma warning disable 618
				c.DescribeAllEnumsAsStrings();
#pragma warning restore 618

				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
			});
			
			services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			if (!env.IsDevelopment())
				app.UseSpaStaticFiles();

			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
				options.DocExpansion(DocExpansion.None);
			});
			
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					"default",
					"{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
					spa.UseAngularCliServer("start");
			});
		}
	}
}