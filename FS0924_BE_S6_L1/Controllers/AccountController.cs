using System.Security.Claims;
using FS0924_BE_S6_L1.Models;
using FS0924_BE_S6_L1.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_BE_S6_L1.Controllers
{
    [Authorize]
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



        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
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
            await _userManager.AddToRoleAsync(user, "Studente");


            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                    TempData["Error"] = "Errore nella fase di login";
                    RedirectToAction("Login");
            }
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (user == null)
            {
                TempData["Error"] = "Nome Utente o Password errati!";
                RedirectToAction("Login");
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, true,false);
            if (result == null)
            {
                TempData["Error"] = "Nome Utente o Password errati!";
                RedirectToAction("Login");
            }
            var roles = await _signInManager.UserManager.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.GivenName, user.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role , role));
            }
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme );

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }
    }
}
