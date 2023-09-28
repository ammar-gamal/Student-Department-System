using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Project.ActionFilter
{
    public class MyExceptionHandler:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception!=null)
            {
                context.ExceptionHandled = true;//that mean the exception is handled
                context.Result = new ViewResult() { ViewName = "ErrorHandle" };

            }
            base.OnActionExecuted(context);
        }
    }
}
