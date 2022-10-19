using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GraduationWeb.Controllers
{
    public class MainPageController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var temp = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.name = temp;
            return View();
        }    
    }
}
