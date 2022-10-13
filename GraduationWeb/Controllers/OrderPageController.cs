using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWeb.Controllers
{
    [Authorize]
    public class OrderPageController : Controller
    {
        public IActionResult Index()
        {
           //HttpContext.User.Identity.Name

            return View();
        }





    }
}
