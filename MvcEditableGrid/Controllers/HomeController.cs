using MvcEditableGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEditableGrid.Controllers
{
    public class HomeController : Controller
    {
        PersonContext db = new PersonContext();
        // GET: Home
        public ActionResult Index()
        {
            List<PersonViewModel> model = new List<PersonViewModel>();

            db.EditablePerson.ToList().ForEach(i =>
            {
                model.Add(new PersonViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Age = i.Age
                });
            });

            //var model = db.EditablePerson;

            return View(model);
        }
        public ActionResult AddNewRow(string rowId)
        {
            ViewBag.rowId = rowId;
            return View();
        }

        public ActionResult Save(List<PersonViewModel> models)
        {
            foreach (var item in models.Where(x => !x.IsDeleted).ToList())
            {
                if (item.Id > 0)// item exist then Update Them
                {
                    var personItem = new EditablePerson
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Age = item.Age
                    };
                    db.EditablePerson.Add(personItem);

                    db.Entry(personItem).State = System.Data.Entity.EntityState.Modified;
                }
                else // add new Item
                {
                    var personItem = new EditablePerson
                    {
                        Name = item.Name,
                        Age = item.Age
                    };
                    db.EditablePerson.Add(personItem);
                }
            }

            if (db.SaveChanges() == 1)
                return Json(new JsonMessage { Success = true, Message = "Data Saved" }, JsonRequestBehavior.AllowGet);

            return Json(new JsonMessage { Success = true, Message = "Error Try Again" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Remove(int rowId)
        {
            var person = db.EditablePerson.FirstOrDefault(x => x.Id == rowId);
            if (person != null)
            {
                db.Entry(person).State = System.Data.Entity.EntityState.Deleted;
                db.EditablePerson.Remove(person);
                if (db.SaveChanges() == 1)
                    return Json(new JsonMessage { Success = true, Message = "Item Deleted" }, JsonRequestBehavior.AllowGet);

                return Json(new JsonMessage { Success = false, Message = "Error Try Again" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new JsonMessage { Success = false, Message = "item not find" }, JsonRequestBehavior.AllowGet);
            }

        }

    }



    public class PersonViewModel : ITableStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; }
    }

    public interface ITableStatus
    {
        bool IsDeleted { get; set; }
    }

}