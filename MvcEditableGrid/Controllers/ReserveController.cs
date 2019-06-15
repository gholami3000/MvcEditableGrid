using MvcEditableGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEditableGrid.Controllers
{
    public class ReserveController : Controller
    {
        // GET: Reserve
        public ActionResult Index()
        {
            var reserve = new ReserveViewModel();
            //person.Persons = GetPerson();
            return View(reserve);
        }

      

        [HttpPost]
        public ActionResult Index(ReserveViewModel model)
        {
            //check model.Interests to see what is posted
            return View(model);
        }

        public ActionResult AddNew()
        {
            var newItem = new tblBookReserve ();
            //check model.Interests to see what is posted
            return PartialView("ReserveEditor", newItem);
        }
    }
}