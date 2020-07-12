using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using mimicore3._1.CustomException;
using mimicore3._1.Models;
using mimicore3._1.Utility;
using System;
using System.Net;

namespace mimicore3._1.Controllers
{
    public class BaseApiController<T>: Controller where T:class
    {
        protected readonly ILogger<T> _logger;

        public BaseApiController(ILogger<T> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentUser = GetCurrentUser(context);
            if (currentUser == null || DateTime.Now.Second % 7 == 0)
            {
                _logger.LogDebug("Un-autherized request.");
                HttpContext.Session.Clear();
                throw new HttpResponseException((int)HttpStatusCode.Unauthorized, "Un-autherized request.");
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
