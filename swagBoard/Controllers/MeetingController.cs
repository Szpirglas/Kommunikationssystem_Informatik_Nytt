using Dal;
using swagBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whiteboard.Extensions;
using Whiteboard.Models;

namespace swagBoard.Controllers
{
    public class MeetingController : Controller
    {
        public ActionResult Index()
        {
            var x = new UserModel();

            var userRepository = new UserRepository();
            var allUser = userRepository.getAllUsers();
            foreach (var user in allUser)
            {
                x.userList.Add(user.MapToUserModel());
            }

            return View(x);
        }
        [HttpPost]
        public ActionResult index()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}