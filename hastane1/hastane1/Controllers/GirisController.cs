using hastane1.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;



namespace hastane1.Controllers
{
    public class GirisController : Controller
    {
        private readonly AppDbContext _context;
        public GirisController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Giris()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Giris(Girisviewmodel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == model.Username);

                if (user != null)
                {
                    if (model.Password == user.Password)
                    {
                        var claims = new List<Claim>
                        {
                           new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                           new Claim(ClaimTypes.Role, user.Role)
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Incorrect password.");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "No account found with this email.");
                }
            }

            return View(model);
        }
        public IActionResult Logout()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            return RedirectToAction("Index", "Home");
        }

    }

}