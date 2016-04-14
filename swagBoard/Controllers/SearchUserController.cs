using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal;
using Whiteboard.Models;

namespace swagBoard.Controllers
{
    public class SearchUserController : Controller
    {
        public ActionResult searchUser()
        {
            var x = new UserModel();

            var userRepository = new UserRepository();
            var allUser = userRepository.getAllUsers();
            //foreach(var user in allUser)
            //{
            //    x(user.);
            //}
            return View();
        }
    }
}