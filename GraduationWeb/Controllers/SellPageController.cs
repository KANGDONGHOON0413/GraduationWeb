﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWeb.Controllers
{
    public class SellPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
