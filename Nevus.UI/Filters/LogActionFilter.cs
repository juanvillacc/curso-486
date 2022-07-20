using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Nevus.UI.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string accion = context.ActionDescriptor.RouteValues["action"];
            Debug.WriteLine($"{accion} iniciada");
            base.OnActionExecuting(context);    
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            string accion = context.ActionDescriptor.RouteValues["action"];
            Debug.WriteLine($"{accion} Terminada");

        }
    }
}
