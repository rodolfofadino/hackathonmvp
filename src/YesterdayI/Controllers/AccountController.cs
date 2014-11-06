using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using YesterdayI.Models;

namespace YesterdayI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
        public SignInManager<ApplicationUser> SignInManager { get; private set; }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //TODO:retornar o erro
                return new HttpStatusCodeResult(500);
            }

            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                //TODO:retornar o erro
                // return GetErrorResult(result);
                return new HttpStatusCodeResult(500);
            }

            return new HttpStatusCodeResult(200);
        }


    }
}