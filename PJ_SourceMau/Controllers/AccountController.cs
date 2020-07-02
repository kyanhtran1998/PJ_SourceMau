using PJ_SourceMau.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using PJ_SourceMau.Repositories;

using AuthenticationProperties = Microsoft.AspNetCore.Authentication.AuthenticationProperties;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using DCSL.DatabaseFactory;
using PJ_SourceMau.Caption;

namespace PJ_SourceMau.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegistrationModel userModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(userModel);
                }
                List<Account> lstacc = AccountRes.GetAll();
                int countAcc = 0;
                for (int i = 0; i < lstacc.Count; i++)
                {
                    if (lstacc[i].username == userModel.Username)
                    {
                        countAcc = 1;
                    }
                }
                if (countAcc == 1)
                {
                    ModelState.AddModelError("1", "UserName already exists! Please try another.");
                }
                else
                {
                    int resultAcc = AccountRes.InsertRegisterAccount(userModel.Username, userModel.Password);
                    int resultDetails = AccountRes.InsertRegisterDetails(userModel.Username, userModel.FullName,
                                            userModel.Email, userModel.PhoneNumber, userModel.Address, resultAcc);
                    return RedirectToAction("Index", "HomeDrugstore");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserLoginModel userModel, string returnUrl = null)
        {
            try
            {
                // Verification.
                if (ModelState.IsValid)
                {
                    List<Account> lst = AccountRes.GetAll();
                    string usertemp = "";
                        for (int i = 0; i < lst.Count; i++)
                        {
                            if ((lst[i].username == userModel.Username) && (lst[i].password == userModel.Password))
                            {
                                usertemp = lst[i].username;
                            DEntity<AccountDetail> e = new DEntity<AccountDetail>(ConstValue.ConnectionString, AccountDetail.getTableName());
                            AccountDetail lstDetail = e.get("iduser", lst[i].id);
                            this.SignInUser(lst[i].id, lst[i].groupId, lst[i].username, lstDetail.name, userModel.RememberMe);

                                Console.WriteLine("user", User.Identity.Name);
                            //Console.WriteLine("userdata", claims[1].Value);
                            Console.WriteLine("user", User.Identity.AuthenticationType);
                            return this.RedirectToAction("Index", "HomeDrugstore");
                             }
                        } 
                        if(usertemp == "")
                        {
                         ModelState.AddModelError(string.Empty, "Invalid username or password.");
                                }      
                    }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            // If we got this far, something failed, redisplay form
            return this.View(userModel);
        }

        private async void SignInUser(int id, int groupId, string username, string fullname, bool isPersistent)
        {
            // Initialization.
            var claims = new List<Claim>();

            try
            {
                // Setting
                claims.Add(new Claim(ClaimTypes.Name, username));
                claims.Add(new Claim("UserId", id.ToString()));
                claims.Add(new Claim("GroupId", groupId.ToString()));
                claims.Add(new Claim("FullName", fullname));
                var claimIdenties = new ClaimsIdentity(claims, "Cookies");
                ClaimsPrincipal principal = new ClaimsPrincipal();
                principal.AddIdentity(claimIdenties);
                // sign-in
                await HttpContext.SignInAsync(
                        scheme: "securityScheme",
                        principal: principal,
                        properties: new AuthenticationProperties
                        {
                        IsPersistent = isPersistent, // for 'remember me' feature
                        //ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
                    });
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                    scheme: "securityScheme");

            return RedirectToAction("Login", "Account");
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}