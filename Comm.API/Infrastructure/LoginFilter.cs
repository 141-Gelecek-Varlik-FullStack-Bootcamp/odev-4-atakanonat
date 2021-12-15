using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;

namespace Comm.API.Infrastructure
{
    public class LoginFilter : Attribute, IActionFilter
    {
        private readonly IMemoryCache memoryCache;
        public LoginFilter(IMemoryCache _memoryCache)
        {
            memoryCache = _memoryCache;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            memoryCache.TryGetValue(key: "LoggedUser", out Comm.Model.Common<Model.User.User> userLog);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!(memoryCache.TryGetValue(key: "LoggedUser", out Comm.Model.Common<Model.User.User> user)))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "User", Action = "login" }));
            }
        }
    }
}