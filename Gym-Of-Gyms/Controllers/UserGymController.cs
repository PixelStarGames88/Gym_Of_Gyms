using Gym_Of_Gyms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Of_Gyms.Controllers;

public class UserGymController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UserGymController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAccount(string login, string password, string confirmPassword, string firstName, string lastName, string fatherName, double weight, double height)
    {
        if (password != confirmPassword)
        {
            ModelState.AddModelError("", "Пароли не совпадают!");
            return RedirectToAction("Registration", "Home");
        }
        var user = new ApplicationUser
        {
            UserName = login,
            Email = login,
            FirstName = firstName,
            LastName = lastName,
            FatherName = fatherName,
            Weight = weight,
            Height = height
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("ProductLine", "Home");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return RedirectToAction("Registration", "Home");
        }
    }
    [HttpPost]
    public async Task<IActionResult> EnterToAccount(string login, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(
            login,
            password,
            isPersistent: false,
            lockoutOnFailure: false
        );

        if (result.Succeeded)
        {
            return RedirectToAction("ProductLine", "Home");
        }
        else
        {
            ModelState.AddModelError("", "Неверный логин или пароль");
            return RedirectToAction("Autorisation", "Home");
        }
    }
}