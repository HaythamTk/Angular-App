using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Bookify.Web.Filters
{
    //to user cant go from item to item from url or page to page (change id)
    public class isTest : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            var request = routeContext.HttpContext.Request;
           // var isTest = request.Headers["Sec-Fetch-Site"] == ("same-origin" || "same-site");
            var isTest = request.Headers["Sec-Fetch-Site"] == "same-origin" || request.Headers["Sec-Fetch-Site"] == "same-site";
            return isTest;
        }
    }
}
