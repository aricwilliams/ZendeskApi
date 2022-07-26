using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUI.Controllers
{
    [Authorize]
    public class HomeRequest : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
