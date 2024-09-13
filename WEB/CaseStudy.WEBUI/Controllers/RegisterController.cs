using CaseStudy.DTO.RegisterDto;
using CaseStudy.EntityLayer.Concrete;
using CaseStudy.WEBUI.Helper;
using CaseStudy.WEBUI.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.WEBUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;

        public RegisterController(UserManager<AppUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


       [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var appUSer = new AppUser()
            {
                Name = createNewUserDto.Name,
                Surname = createNewUserDto.Surname,
                Email = createNewUserDto.Email,
                PhoneNumber = createNewUserDto.Phone,
                UserName = createNewUserDto.Email

            };
            MailRequest mailRequest = new MailRequest();
            var result = await _userManager.CreateAsync(appUSer,createNewUserDto.Password);
            if(result.Succeeded)
            {
                mailRequest.ToEmail = createNewUserDto.Email;
                mailRequest.Subject = "welcome to meeting";
                mailRequest.Body = "Thanks for register";
                await _emailService.SendEmailAsync(mailRequest);
                return RedirectToAction("Index","Login");
                
            }
            return View();
        }


       
    }
}
