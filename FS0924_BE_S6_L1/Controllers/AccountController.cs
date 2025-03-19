using FS0924_BE_S6_L1.Models;
using FS0924_BE_S6_L1.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_BE_S6_L1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "Errore nella fase di login";
                    RedirectToAction("Login");
                }
            }
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (user == null) 
            {
                TempData["Error"] = "Nome Utente o Password errati!";
                RedirectToAction("Login");
            }

            return RedirectToAction("Index");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) {
                TempData["Error"] = "Errore nella fase di registrazione";
                RedirectToAction("Register");
            }
            var newUser = new ApplicationUser()
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email,
                BirthDate = registerViewModel.BirthDate,
            };
            var result = await _userManager.CreateAsync(newUser, registerViewModel.Password);
            if (!result.Succeeded)
            {
                TempData["Error"] = "errore in fase di registrazione";
                RedirectToAction("Register");
            }
            var user = await _userManager.FindByEmailAsync(newUser.Email);
            await _userManager.AddToRoleAsync(user, "User");


            return RedirectToAction("Index");
        }


    }
}
