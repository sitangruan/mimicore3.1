using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mimicore3._1.Models;
using mimicore3._1.Utility;

namespace mimicore3._1.Controllers
{
    public class LoginController : Controller
    {
        protected readonly ILogger<LoginController> _logger;
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody]LoginModel loginModel)
        {
            var success = false;
            var errorMessage = "";

            if (string.IsNullOrEmpty(loginModel.UserName) || string.IsNullOrEmpty(loginModel.Password))
            {
                //Just a basic validation to ensure user name and password are not empty.
                errorMessage = "The UserName and Password cannot be empty.";
                _logger.LogWarning("An invalid login attemp with empty UserName or Password.");
            }
            else if (loginModel.UserName.Equals(loginModel.Password))
            {
                //We implement the simplest validation by comparing the user name and password to be same. That is only for dmeo.
                success = true;
                var currentUser = new User() { UserName = loginModel.UserName };
                HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(currentUser));
                _logger.LogInformation($"{loginModel.UserName} successfully login.");
            }
            else
            {
                errorMessage = "The UserName and Password don't match.";
                _logger.LogWarning($"\"{loginModel.UserName}\" is trying to login with an unmatched password.");
            }

            return Json(new LoginResult()
            {
                Success = success,
                ErrorMessage = errorMessage
            });
        }
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
