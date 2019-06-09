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
       

      
        public ActionResult Index()
        {
            var person = new PersonViewModel2();
            person.Persons = GetPerson();
            return View(person);
        }

        private static List<EditablePerson> GetPerson()
        {
            PersonContext db = new PersonContext();
            //var PersonList = new List<PersonViewModel2>();
            //PersonList.Add(new PersonViewModel2 { Id = 1, Name = "a",Family="aa",Age=20 });
            //PersonList.Add(new PersonViewModel2 { Id = 2, Name = "b", Family = "bb",Age=30 });

            //interestList.Add(new UserInterest { Id = 2, InterestText = "asp.net", Option = 3 });

            var personList = db.EditablePerson.ToList();
            return personList;
        }

        [HttpPost]
        public ActionResult Index(PersonViewModel2 model)
        {
            //check model.Interests to see what is posted
            return View(model);
        }

        public ActionResult AddNew()
        {
            var newItem = new EditablePerson {Id=0,Name="",Family="",Age=0 };
            //check model.Interests to see what is posted
            return PartialView("PersonEditor", newItem);
        }

    }
}