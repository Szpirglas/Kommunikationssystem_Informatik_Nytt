using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Whiteboard.Models;

namespace Whiteboard.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(UserModel model)
        {
            var addRoles = new RolesController();
            var userRep = new UserRepository();
            var user = new User();
            {
                user.Email = model.Email;
                user.Password = model.Password;
                user.Firstname = model.Firstname;
                user.Lastname = model.Lastname;
                user.Phonenumber = model.PhoneNumber;
                user.ResearchAdmin = model.ResearchAdmin;
                user.EducationAdmin = model.EducationAdmin;
                user.Doctorand = model.Doctorand;
                user.Lecturer = model.Lecturer;
                user.Researcher = model.Researcher;

            }
            userRep.addUser(user);
            addRoles.addUserToRole(model);
            return RedirectToAction("index", "Home");
        }
        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginUser(UserModel model)
        {
            var addRoles = new RolesController();
            var userRepository = new UserRepository();
            var lowerEmail = model.Email.ToLower();

            if (userRepository.checkUserLogin(lowerEmail, model.Password))
            {
                var user = userRepository.getYaUserFromYaMail(lowerEmail);

                var newModel = new UserModel
                {
                    Doctorand = user.Doctorand,
                    EducationAdmin = user.EducationAdmin,
                    Email = user.Email,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Lecturer = user.Lecturer,
                    Password = user.Password,
                    PhoneNumber = user.Phonenumber,
                    ResearchAdmin = user.ResearchAdmin,
                    Researcher = user.Researcher
                };
                addRoles.addUserToRole(newModel);
                FormsAuthentication.SetAuthCookie(model.Email, false);

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("index", "Home");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return  RedirectToAction("index", "Home");

        }

    }
}