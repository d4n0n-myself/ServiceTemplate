using Microsoft.AspNetCore.Components;
using Template.Core.EntityServices.Base;
using Template.Models.Entities;

namespace Template.Web.Controllers
{
	[Route("[controller]/[action]")]
	public class Model2Controller : BaseController<Model2>
	{
		public Model2Controller(BaseDomainService<Model2> service) : base(service)
		{
		}
	}
}