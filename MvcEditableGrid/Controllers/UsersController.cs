using MvcEditableGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MvcEditableGrid.Models.User;

namespace MvcEditableGrid.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
       

        [HttpPost]
        public ActionResult Index(User model)
        {
            //check model.Interests to see what is posted
            return View(model);
        }
        public ActionResult Index()
        {
            var usr = new User();
            usr.Interests = GetUserInterests();
            return View(usr);
        }

        private static List<UserInterest> GetUserInterests()
        {
            var interestList = new List<UserInterest>();
            interestList.Add(new UserInterest { Id = 1, InterestText = "", Option = 2 });
            interestList.Add(new UserInterest { Id = 2, InterestText = "asp.net", Option = 3 });
            return interestList;
        }
    }
}