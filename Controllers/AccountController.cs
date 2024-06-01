using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Hermes.ViewModels;
using Hermes.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager; // Adicione isso

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager) // Adicione isso
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager; // Adicione isso
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("index", "home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        return View(model);
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var roles = user != null ? await _userManager.GetRolesAsync(user) : null; // Retrieve the user's roles

                var role = roles?.FirstOrDefault();
                if (role != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, role), // Use the first role from the roles list
                    };

                    var userIdentity = new ClaimsIdentity(claims, "login");
                    var principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("index", "home");
                }
            }
            
            ModelState.AddModelError("", "Invalid login attempt.");
        }
        
        return View(model);
    }

    // Adicione este método para logout
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // Adicione este método para obter o Role do usuário
    public async Task<IActionResult> GetUserRole()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            var roles = await _userManager.GetRolesAsync(user);
            // Agora você tem os roles do usuário
        }

        // ...
        return View();
    }
}