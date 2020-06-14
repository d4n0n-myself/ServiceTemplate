using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Template.Models;

namespace Template.Web.Filters
{
	public class PrettyFilter : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			if (context.Exception != null)
			{
				context.Result = new OkObjectResult(Result.Failure(context.Exception.Message));
				context.ExceptionHandled = true;
				context.Exception = null;
			}
 
			if (context.Result is OkResult)
				context.Result = new OkObjectResult(Result.Successful());

			base.OnActionExecuted(context);
		}
	}
}