using Microsoft.AspNetCore.Mvc;

namespace Gym_Of_Gyms.Controllers;

public class UserGymController : Controller
{
    [HttpPost]
    public async Task<IActionResult> CreateAccount(string login, string password, string firstName, string lastName, string fatherName, double weight, double height)
    {
        var dataBaseConnector = new Models.DataBaseConnector.DataBaseConnector(HttpContext.RequestServices.GetService<IConfiguration>() ?? throw new NullReferenceException());
        var userGym = await dataBaseConnector.CreateAccount(login, password, firstName, lastName, fatherName, weight, height);
        if (userGym != null)
        {
            return RedirectToAction("ProductLine", "Home");
        }
        else
        {
            return RedirectToAction("Registration", "Home");
        }
    }
    [HttpPost]
    public async Task<IActionResult> EnterToAccount(string login, string password)
    {
        var dataBaseConnector = new Models.DataBaseConnector.DataBaseConnector(HttpContext.RequestServices.GetService<IConfiguration>() ?? throw new NullReferenceException());
        var userGym = await dataBaseConnector.EnterToAccount(login, password);
        if (userGym != null)
        {
            return RedirectToAction("ProductLine", "Home");
        }
        else
        {
            return RedirectToAction("Autorisation", "Home");
        }
    }
}