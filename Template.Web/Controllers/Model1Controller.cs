using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Template.Core.EntityServices.Base;
using Template.Models.Entities;
using Template.Models.Enums;

namespace Template.Web.Controllers
{
	[Microsoft.AspNetCore.Components.Route("[controller]/[action]")]
	public class Model1Controller : BaseController<Model1>
	{
		public Model1Controller(BaseDomainService<Model1> service) : base(service)
		{
		}

		// to generate enum to swagger schema
		[HttpGet]
		public async Task<IActionResult> Test(TestEnum value)
		{
			await Task.CompletedTask;
			return Ok();
		}
	}
}