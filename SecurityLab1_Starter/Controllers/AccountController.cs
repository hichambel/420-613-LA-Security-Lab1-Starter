﻿using SecurityLab1_Starter.Infrastructure.Abstract;
using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SecurityLab1_Starter.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    Logger log = new Logger();
                    using (StreamWriter w = System.IO.File.AppendText("C:\\temp\\log.txt"))
                    {
                        log.LogToFile(model.UserName + " has logged in", w);
                    }
                    return RedirectToAction("Login", "Account");
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Your credentials are incorrect");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();

            Logger log = new Logger();

            using (StreamWriter w = System.IO.File.AppendText("C:\\temp\\log.txt"))
            {
                log.LogToFile(HttpContext.User.Identity.Name + " has logged out", w);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}