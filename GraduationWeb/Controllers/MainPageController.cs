using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWeb.Controllers
{
    public class MainPageController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {          
            return View();
        }

        
    }
}
