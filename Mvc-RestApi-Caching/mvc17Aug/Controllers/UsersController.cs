using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using mvc17Aug.Models;
using System.Security.Claims;

namespace mvc17Aug.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Login(Users user)
        {
            if(user.UserName=="admin" && user.Password=="password")
            {
                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,"admin"),
                    new Claim(ClaimTypes.Role,"admin")

                };

                var identity = new ClaimsIdentity(claim, "MyCookieAuth");

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                var AuthProperties = new AuthenticationProperties
                {
                    IsPersistent = user.RememberMe
                };

                await HttpContext.SignInAsync("MyCookieAuth", principal, AuthProperties);

                return Redirect("../Home/Index");
            }
            else
            {
                if (user.UserName == "professor" && user.Password == "password")
                {
                    var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,"professor"),
                    new Claim(ClaimTypes.Role,"professor"),
                    new Claim("EmploymentDate","2022-08-15")

                };

                    var identity = new ClaimsIdentity(claim, "MyCookieAuth");

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    var AuthProperties = new AuthenticationProperties
                    {
                        IsPersistent = user.RememberMe
                    };

                    await HttpContext.SignInAsync("MyCookieAuth", principal, AuthProperties);

                    return Redirect("../Home/Index");
                }
            }
            return View("Login");
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return Redirect("Login");
        }

        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}

