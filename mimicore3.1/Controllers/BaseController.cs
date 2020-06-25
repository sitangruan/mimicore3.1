using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using mimicore3._1.Models;
using mimicore3._1.Utility;
using System;

namespace mimicore3._1.Controllers
{
    public class BaseController<T>: Controller where T:class
    {
        protected readonly ILogger<T> _logger;

        public BaseController(ILogger<T> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentUser = GetCurrentUser(context);
            if (currentUser == null)
            {
                _logger.LogDebug("Un-autherized request.");
                HttpContext.Session.Clear();
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
                return;
            }
            base.OnActionExecuting(context);
        }

        private User GetCurrentUser(ActionExecutingContext context)
        {
            if (HttpContext.Session.TryGetValue("CurrentUser", out byte[] userBytes))
            {
                return ByteConvertHelper.Bytes2Object<User>(userBytes);
            }

            return null;
        }
    }
}
