using FinalProject.EntityF;

using FinalProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace webApp_mvc.Controllers
{
     public class AccountController : Controller
     {
         private UserManager<User> _mng;
         private SignInManager<User> _signInManager;
         private AppDbContext _dbContext;
         public AccountController(UserManager<User> UserMng, SignInManager<User> signInManager, AppDbContext dbContext)
         {
             _mng = UserMng;
             _signInManager = signInManager;
             _dbContext = dbContext
         }
         [HttpGet]
         public IActionResut Register()
         {
             return View();
         }


         [HttpPost]
         public IActionResult Register(UserRegistrationModel R)
         {
             if (IModelState.IsValid)
             { return View(R); }

             var NewUser = new User { User_Name = R.First_Name+" "+R.Last_Name,UserName = R.Email, Email = R.Email };
             var Result = _mng.CreateAsync(NewUser,R.Password).Result;

             Result= _mng.AddToRoleAsync(NewUser, Enum.GetName(typeof(UserType), R.Type)).Result;

             if (Result.Succeeded == false)
             {
                 foreach (var item in Result.Errors)
                 {
                     ModelState.TryAddModelError("Error",error);
                 }
                 return View(R);
             }
             if (R.Type == UserType.Staff)
             {
                 var stf = new Staff { Staff_Name = R.First_Name + " " + R.LastName, Email = R.Email };
                 _dbContext.Add(stf);
                 _dbcontext.SaveChanges();
                 NewUser.User_ID = stf.Staff_ID;
             }
             else
             {
                 var mgr = new Manager { Manager_Name = R.First_Name +" " + R.Last_Name, Email = R.Email };
                 _dbContext.Add(mgr);
                 _dbContext.SaveChanges();
                 NewUser.User_ID = mgr.Manager_ID;
             }
             Result= _mng.UpdateAsync(NewUser).Result;
             return RedirectToAction("Login", "Account")
         }

         [HttpGet]
         public IActionResult Login()
         {
             return View();
         }

         [HttpPost]
         public IActionResult Login(UserLoginModel _userlogin)
         {

             if (!ModelState.IsValid)
             { return View(_userlogin); }
             var user = _mng.FindByEmailAsync(_userlogin.Email).Result;
             if (user != null && _mng.CheckPasswordAsync(user, _userlogin.Password).Result == true)
             {
                 var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
             var roles =_mng.GetRolesAsync(user).Result;

                 foreach (var role in roles)
                 {
                     identity.AddClaim(new Claim(ClaimTypes.Role, role));
                 }
                 identity.AddClaim(new Claim("User_ID",user.User_ID.toString()));
                 HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(Identity));
                return RedirectToAction("Index","Course");
             }
             else
             {
                 ModelState.AddModelError("Error", "Ivalid UserName or Password");
                 return View();
             }
         }
         public IActionResult AccessDenied()
         {
             return View();
         }

         public async Task<IActionResult> SignOut()
         {

             await _signInManager.SignOutAsync();
                 return RedirectToActio("Login", "Account");
         }
     }
}
