using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebBookingApp.Models;

namespace WebBookingApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // 🔹 Verifică dacă adminul este logat
        if (HttpContext.Session.GetString("AdminLoggedIn") != "true")
        {
            return RedirectToAction("Login", "AdminAuth"); // 🔹 Redirecționează către pagina de login
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}