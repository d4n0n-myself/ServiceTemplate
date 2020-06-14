using Microsoft.AspNetCore.Components;
using Template.Core.EntityServices.Base;
using Template.Models.Entities;

namespace Template.Web.Controllers
{
	[Route("[controller]/[action]")]
	public class Model3Controller : BaseController<Model3>
	{
		public Model3Controller(BaseDomainService<Model3> service) : base(service)
		{
		}
	}
}