using Microsoft.AspNetCore.Mvc;

namespace Gym_Of_Gyms.Controllers;

public class HomeController : Controller
{
    public IActionResult Autorisation()
    {
        return View();
    }

    public IActionResult Registration()
    {
        return View();
    }
    public IActionResult ProductLine()
    {
        return View();
    }

}