using Hospital.DAL.DataContext;
using Hospital.DAL.DataContext.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hospital.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : AdminController
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Login sayfası
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login işlemi
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = _context.AdminUsers
                               .FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user == null)
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı!";
                return View();
            }

            // Cookie claim oluştur
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var identity = new ClaimsIdentity(claims, "AdminCookie");
            var principal = new ClaimsPrincipal(identity);

            // Cookie yaz (kalıcı olmasın)
            await HttpContext.SignInAsync("AdminCookie", principal, new AuthenticationProperties
            {
                IsPersistent = false, // Tarayıcı kapanınca cookie silinsin
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30), // Maksimum 30 dk
                AllowRefresh = true
            });

            // Session’a rol ekle (SuperAdminOnly için)
            HttpContext.Session.SetString("AdminRole", user.Role.ToString());

            return RedirectToAction("Index", "Dashboard");
        }

        // Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("AdminCookie");
            HttpContext.Session.Clear(); // Session’ı da temizle
            return RedirectToAction("Login");
        }
    }
}