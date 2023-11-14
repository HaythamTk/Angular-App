using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Bookify.Web.Filters
{
    //filter to Sure if the request from ajax call or no
    public class AjaxOnly : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            var request = routeContext.HttpContext.Request;
            var isAjax = request.Headers["x-requested-with"] == "XMLHttpRequest";
            return isAjax;
        }
    }
}
