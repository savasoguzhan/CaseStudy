using CaseStudy.DTO.LoginDto;
using CaseStudy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.WEBUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUserDto.Email, loginUserDto.Password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Meeting");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
             await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
