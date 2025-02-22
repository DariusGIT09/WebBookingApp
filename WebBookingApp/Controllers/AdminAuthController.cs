using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebBookingApp.Controllers
{
    public class AdminAuthController : Controller
    {
        private readonly string AdminUsername = "admin";
        private readonly string AdminPassword = "admin123";

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == AdminUsername && password == AdminPassword)
            {
                HttpContext.Session.SetString("AdminLoggedIn", "true"); // 🔹 Salvăm sesiunea
                return RedirectToAction("Index", "Home"); // 🔹 Redirect către homepage
            }

            ViewBag.Error = "Invalid username or password!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminLoggedIn"); // 🔹 Ștergem sesiunea
            return RedirectToAction("Login");
        }
    }
}