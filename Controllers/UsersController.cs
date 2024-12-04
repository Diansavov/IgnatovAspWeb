using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestIgnatov.Models;
using TestIgnatov.Models.ViewModels.User;

namespace TestIgnatov.Controllers;

public class UsersController : Controller
{
    private readonly UserManager<Users> _userManager;
    private readonly SignInManager<Users> _signInManager;
    public UsersController(UserManager<Users> userManager, SignInManager<Users> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(UserRegister userRegister)
    {
        if (ModelState.IsValid)
        {
            Users user = new Users()
            {
                UserName = userRegister.UserName,
                Email = userRegister.Email,
                DateOfBirth = userRegister.DateOfBirth,
            };
            var result = await _userManager.CreateAsync(user, userRegister.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }
        }
        return View(userRegister);
    }



    public IActionResult LogIn()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LogIn(UserLogin logInRequest)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByNameAsync(logInRequest.UserName);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, logInRequest.Password);

                if (passwordCheck)
                {
                    await _signInManager.PasswordSignInAsync(user, logInRequest.Password, false, false);
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        return View(logInRequest);
    }

    public IActionResult LogOut()
    {
        _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}
