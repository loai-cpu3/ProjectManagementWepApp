using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels.AccountViewModels;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {

            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View("Auth");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.username, loginModel.password, true, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Username or Password");
                return View("Auth", new AuthViewModel() { LoginModel = loginModel, SignUpModel = new SignUpViewModel() });

            }
            return View("Auth", new AuthViewModel() { LoginModel = loginModel, SignUpModel = new SignUpViewModel() });

        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User() { UserName = signUpModel.UserName, Email = signUpModel.Email };
                var result = await _userManager.CreateAsync(user, signUpModel.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("Auth", new AuthViewModel() { LoginModel = new LoginViewModel(), SignUpModel = signUpModel });
            }
            return View("Auth", new AuthViewModel() { LoginModel = new LoginViewModel(), SignUpModel = signUpModel });
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }
}