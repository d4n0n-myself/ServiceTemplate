using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Template.Core.EntityServices.Base;
using Template.Models;
using Template.Models.Entities.Base;
using Template.Web.Filters;

namespace Template.Web.Controllers
{
	[PrettyFilter]
	[Route("[controller]/[action]")]
	public class BaseController<T> : Controller where T : HaveId
	{
		protected readonly BaseDomainService<T> Service;

		public BaseController(BaseDomainService<T> service)
		{
			Service = service;
		}

		[HttpPost]
		public virtual async Task<IActionResult> Delete(long id)
		{
			await Service.DeleteAsync(id);
			return Successful();
		}

		[HttpGet]
		public virtual async Task<IActionResult> Get(long id)
		{
			var data = await Service.GetAsync(id);
			return Successful(data);
		}

		[HttpGet]
		public virtual async Task<IActionResult> GetAll()
		{
			var data = await Service.GetAllAsync();
			return Successful(data);
		}

		[HttpPost]
		public virtual async Task<IActionResult> Update([FromBody] T entity)
		{
			await Service.UpdateAsync(entity);
			return Successful();
		}

		[HttpPost]
		public virtual async Task<IActionResult> Save([FromBody] T entity)
		{
			await Service.SaveAsync(entity);
			return Successful();
		}

		protected IActionResult Successful()
		{
			return new OkObjectResult(Result.Successful());
		}

		protected IActionResult Successful<T>(T data)
		{
			return new OkObjectResult(DataResult<T>.Successful(data));
		}

		protected IActionResult Failure(string message)
		{
			return new OkObjectResult(Result.Failure(message));
		}
	}
}