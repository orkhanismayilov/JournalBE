using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using Journal.Models;
using System.Web.Helpers;

namespace Journal.Controllers
{
    public class AuthorizationController : Controller
    {
        JournalEntities db = new JournalEntities();
        ViewAuth viewAuth = new ViewAuth();

        // GET: Authorization
        public ActionResult Authorization()
        {
            return View();
        }

        // POST: SignUp
        [HttpPost]
        public JsonResult SignUp(FormCollection collection)
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            string password_confirmation = Request.Form["password_confirmation"];

            if (string.IsNullOrWhiteSpace(email))
            {
                var json = new
                {
                    type = "error",
                    errorMsg = "Please, enter your email"
                };

                return Json(json);
            }

            if (!checkEmail(email))
            {
                var json = new
                {
                    type = "error",
                    errorMsg = "Wrong email!"
                };

                return Json(json);
            }

            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(password_confirmation))
            {
                var json = new
                {
                    type = "error",
                    errorMsg = "Please, enter password and password confirmation"
                };

                return Json(json);
            }

            if (password != password_confirmation)
            {
                var json = new
                {
                    type = "error",
                    errorMsg = "Password and password confirmation do not match"
                };

                return Json(json);
            }

            if (db.Users.FirstOrDefault(u => u.email == email) != null)
            {
                var json = new
                {
                    type = "error",
                    errorMsg = "User with this email is already registered"
                };

                return Json(json);
            }

            User user = new User
            {
                email = email,
                password = Crypto.HashPassword(password),
                user_group_id = 0,
                reg_date = DateTime.Now,
                token = Crypto.Hash(email + password + DateTime.Now)
            };

            db.Users.Add(user);
            if (db.SaveChanges() > 0)
            {
                var json = new
                {
                    type = "success",
                    successTitle = "Thank you!",
                    successMsg = "Email with activation link has been sent to your email to finish the registration.<br/>Without activation you will not be able to sign into your account."
                };

                return Json(json);
            }
            else
            {
                var json = new
                {
                    type = "error",
                    errorMsg = "Oops, error has been occured! Please, try again."
                };

                return Json(json);
            }
        }

        private bool checkEmail(string email)
        {
            Regex emailRegex = new Regex("^[a-zA-Z0-9.!#$%&'*+\\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)+$");

            if (!emailRegex.IsMatch(email))
            {
                return false;
            };

            return true;
        }
    }
}