using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Products.BL.ViewModel;

namespace Products.PL.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> UserManager;
        private readonly SignInManager<IdentityUser> SignInManager;

        public AccountController(UserManager<IdentityUser> UserManager, SignInManager<IdentityUser> SignInManager)
        {
            this.UserManager = UserManager;
            this.SignInManager = SignInManager;
        }
        [HttpGet]
        public IActionResult Registeration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registeration(RegisterVM Model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser User = new IdentityUser();

                User.UserName = Model.Username;
                User.Email = Model.Email;

                //save user
                IdentityResult result = await UserManager.CreateAsync(User, Model.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(User, "User");
                    //create cookie
                    await SignInManager.SignInAsync(User, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View(Model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM Model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    IdentityUser User = await UserManager.FindByEmailAsync(Model.Email);

                    if (User != null)
                    {
                        var Res = await SignInManager.PasswordSignInAsync(User, Model.Password, Model.IsPresistent, false);

                        if (Res.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            
                            ModelState.AddModelError("", "Invalid Email Or Password");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Email Or Password");
                    }
                }

                return View(Model);
            }
            catch (Exception)
            {
                return View(Model);
            }

            
        }



        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


    }
}
