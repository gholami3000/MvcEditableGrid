using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEditableGrid.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Person> lst = new List<Person>();
            lst.Add(new Person { Id = 1, Name = "Ali1" });
            lst.Add(new Person { Id = 2, Name = "Ali2" });
            
            return View(lst);
        }
        public ActionResult AddNewRow(string rowId)
        {
            ViewBag.rowId = rowId;
            return View();
        }

        public ActionResult Save(List<Person> models)
        {
            return Json("DataSaved",JsonRequestBehavior.AllowGet);
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}