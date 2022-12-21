using GraduationWeb.Models.IDAL;
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
        private readonly I_ProductM _context;

        public OrderPageController(I_ProductM context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.itemsList = _context.ShowAllProduct(1);

            return View();
        }





    }
}
