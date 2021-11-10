using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public bool DisplayInvalidAccountMessage = false;

        IConfiguration configuration;
        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult OnGet()
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/Pizzas");
            }
            return Page();
        }



    public async Task<IActionResult> OnPost(string username, string password, string ReturnUrl)
    {
        var authSection = configuration.GetSection("Auth");

        string adminLogin = authSection["Adminlogin"];
        string adminPassword = authSection["AdminPassword"];


        if((username == adminLogin)&&(password == adminPassword))
        {
           var claims = new List<Claim>
                {
           new Claim(ClaimTypes.Name, username)
           };

           DisplayInvalidAccountMessage = false;
           var claimsIdentity = new ClaimsIdentity(claims, "Login");
           await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new
           ClaimsPrincipal(claimsIdentity));
           return Redirect(ReturnUrl == null ? "/Admin/Pizzas" : ReturnUrl);
        }
            DisplayInvalidAccountMessage = true;
        return Page();
     }

    public async Task<IActionResult> OnGetLogout()
     {
      await HttpContext.SignOutAsync();
      return Redirect("/Admin");
     }
    }
}
