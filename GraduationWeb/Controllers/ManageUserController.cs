using GraduationWeb.Models.ViewModels;
using GraduationWeb.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using GraduationWeb.Models.DB;
using GraduationWeb.Models.IDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace GraduationWeb.Controllers
{
    public class ManageUserController : Controller
    {
        private readonly I_UserM _context;

        public ManageUserController(I_UserM context)
        {
            _context = context;
        }

        [BindProperty]  //이미지 저장을 위한 단계
        public UpdateUserInfoVM FileUpload { get; set; }

        [Authorize]
        public IActionResult Index()
        {
            string id = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            var temp = _context.GetUserInfo(id);
            ViewBag.MyInfo = temp;
          
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Index(UpdateUserInfoVM model)
        {
            model.Id = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            using (var ms = new MemoryStream())
            {
                FileUpload.FormFile.CopyTo(ms);
                model.Image = ms.ToArray();
            }
            model.FormFile = null;
            bool ckup = _context.UpdateUserInfo(model);


            ViewBag.MyInfo = _context.GetUserInfo(model.Id);
 
            return View();
        }


        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginApproach model)
        {
            if (ModelState.IsValid)
            {
                string UserName = _context.UserLoginCheck(model);
                if (!string.IsNullOrEmpty(UserName))
                {
                    var claims = new List<Claim>
                       {
                           new Claim(ClaimTypes.NameIdentifier, model.ID),
                           new Claim(ClaimTypes.Name, UserName),
                           new Claim("PW",model.Password)
                       };

                    var ClaimsId = new ClaimsIdentity(claims, "Cookies");
                    var Claimsprincipal = new ClaimsPrincipal(ClaimsId);

                    await HttpContext.SignInAsync(
                        "Cookies", Claimsprincipal, new AuthenticationProperties { IsPersistent = false }
                        );
                    return RedirectToAction("Index", "MainPage");
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> UserLogout()
        {
            await HttpContext.SignOutAsync("Cookies");

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> DeleteUser()
        {          
            string id = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            ViewBag.MyInfo = _context.DeleteUser(id);
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Home");
        }


        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(TableUser model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!_context.AddNewUser(model)) throw new Exception("이미 존재하는 아이디이거나 연결에 오류가 있습니다");


                    var claims = new List<Claim>
                       {
                           new Claim(ClaimTypes.NameIdentifier, model.Id),
                           new Claim(ClaimTypes.Name, model.Name),
                           new Claim("PW",model.Password)
                       };

                    var ClaimsId = new ClaimsIdentity(claims, "Cookies");
                    var Claimsprincipal = new ClaimsPrincipal(ClaimsId);

                    await HttpContext.SignInAsync(
                        "Cookies", Claimsprincipal, new AuthenticationProperties { IsPersistent = false }
                        );

                    return RedirectToAction("WellcomePage", "ManageUser");
                }
                catch (Exception exc)
                {
                    ViewBag.errMsg = exc.Message;
                }
            }
            return View(model);
        }

        public IActionResult WellcomePage()
        {
            return View();
        }

    }
}
