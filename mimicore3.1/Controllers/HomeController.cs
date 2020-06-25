using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mimicore3._1.Models;

namespace mimicore3._1.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public HomeController(ILogger<HomeController> logger): base(logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
