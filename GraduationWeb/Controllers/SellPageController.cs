using GraduationWeb.Models.DB;
using GraduationWeb.Models.IDAL;
using GraduationWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Claims;

namespace GraduationWeb.Controllers
{
    [Authorize]
    public class SellPageController : Controller
    {
        private readonly I_ProductM _context;

        public SellPageController(I_ProductM context)
        {
            _context = context;
        }

        [BindProperty]  //이미지 저장을 위한 단계
        public UpdateUserInfoVM FileUpload { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TableSellVM model)
        {

            TableSell items = new TableSell();
            items.ProductName = model.ProductName;
            items.SellerId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            items.ProductPrice = model.ProductPrice;
            items.ProductNum = model.ProductNum;
            items.ProductDescription = model.ProductDescription;

            if (!(model.FormFile is null))
            {
                using (var ms = new MemoryStream())
                {
                    FileUpload.FormFile.CopyTo(ms);
                    items.ProductImage = ms.ToArray();
                }
               
            }

            _context.InputProduct(items);

            return View();
        }
    }
}
