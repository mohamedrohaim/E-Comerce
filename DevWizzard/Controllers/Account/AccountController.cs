using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PresentationLayer.ViewModels.Account;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManger;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManger = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public  async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else {
                var user = new User()
                {
                    UserName=model.Email.Split('@')[0],
                    Email=model.Email,  
                    firstName=model.firstName,
                    lastName=model.lastName,
                };
                

                var result=await _userManger.CreateAsync(user,model.password);
                if (result.Succeeded) 
                    return RedirectToAction(nameof(Login));
               return View(model);
               
                
            
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) {
            if (ModelState.IsValid) { 
            var user=await _userManger.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    bool flag = await _userManger.CheckPasswordAsync(user,model.password);
                    if (flag)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, model.password,model.rememberMe,false);
                        if (result.Succeeded) { 
                        return RedirectToAction("Index","Product");
                        }
                        ModelState.AddModelError(string.Empty, "chekc your connection");
                        return View(model);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Password is in correct");
                        return View(model);
                    }

                }
                else {
                    ModelState.AddModelError(string.Empty, "Email not found");
                }
            
            }
            return View(model);
        }



        public new async Task<IActionResult> Logout() { 
           await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        
        }



    }
}
