using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CssSelector.BL.Enum;
using CssSelector.BL.Service.UserService;
using CssSelector.Common.Entities;
using CssSelector.UI.Models;

namespace CssSelector.UI.Controllers
{
    public class LoginController : Controller
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new UserModel());
        }

        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            //TODO TRY TO FIND BETTER APROACH
            if (ModelState.IsValid)
            {
                var user = _userService.GetUser(model.Email);
                if (user != null)
                {
                    if (user.PasswordHash.Equals(GetHash(model.Password)))
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Frame", "Home");
                    }
                    else
                    {
                        //TODO ::Change this shit
                        ModelState.AddModelError("Email", "");
                        return View(model);
                    }
                }
                else
                {
                    //TODO ::Change this shit
                    ModelState.AddModelError("Email", "");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        //TODO CHANGE CODE
        public ActionResult Registration(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = this._userService.GetUser(model.Email);
                if (user == null)
                {
                    var result = this._userService.InsertUser(new UserEntity
                    {
                        Email = model.Email,
                        PasswordHash = GetHash(model.Password)
                    });
                    if (result == OperationStatus.Success)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Frame", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", String.Empty);
                        return View("Index",model);
                    }
                }
                else
                {
                    ModelState.AddModelError("Email",String.Empty);
                    return View("Index", model);

                }
            }
            else
            {
                return View("Index", model);
            }
        }

        //TODO::Remove this to single class encrypt data
        private string GetHash(string password)
        {
            return System.Text.Encoding.UTF8.GetString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}