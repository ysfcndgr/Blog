using AMS.BLL.Abstract;
using AMS.Model.Relotional;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AMS.WEBUI.Controllers
{
    public class LoginController : Controller
    {
        IWriterService _writerService;
        public LoginController(IWriterService writerService)
        {
            _writerService = writerService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Writer writer)
        {
            var result = _writerService.Login(writer.WriterMail, writer.WriterPassword);
            if (result != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,result.Id.ToString()),
                    new Claim(ClaimTypes.Email,writer.WriterMail),
            };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(principal),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                    });
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.AlertModel = "Kullanıcı adı veya parola yanlış";
            return View();
        }
    }
}
