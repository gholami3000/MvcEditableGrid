using MvcEditableGrid.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                    Family = i.Family,
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

            var v = new ValidateEachItemAttribute();
            v.IsValid(models.Where(x => !x.IsDeleted).ToList());
            var ModelErrorList = v.ModelErrorList.ToList();
            //v.PersonList = models;
            //v.Validate(null);

            if (ModelErrorList.Any())
            {
                return Json(new JsonMessage
                {
                    Success = false,
                    Message = "Please Fill Required Field",
                    Data = JsonConvert.SerializeObject(ModelErrorList)
                }, JsonRequestBehavior.AllowGet);
            }
            ModelState.Clear();
            foreach (var item in models.Where(x => !x.IsDeleted).ToList())
            {
                if (item.Id > 0)// item exist then Update Them
                {
                    var personItem = new EditablePerson
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Family = item.Family,
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
                        Family=item.Family,
                        Age = item.Age
                    };
                    db.EditablePerson.Add(personItem);
                }
            }

            db.SaveChanges();
            return Json(new JsonMessage { Success = true, Message = "Data Saved" }, JsonRequestBehavior.AllowGet);

            //return Json(new JsonMessage { Success = false, Message = "Error Try Again" }, JsonRequestBehavior.AllowGet);
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
        public int ClientId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Family { get; set; }
        [Range(18, 56, ErrorMessage = "Age Must be between 18 to 60")]
        public int Age { get; set; }
        public bool IsDeleted { get; set; }
    }

    //public class ModelItem
    //{
    //    [ValidateEachItem]
    //    public List<PersonViewModel> Things;
    //}

    public interface ITableStatus
    {
        bool IsDeleted { get; set; }
    }

    public class ModelValidate : IValidatableObject
    {
        public List<PersonViewModel> PersonList;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //your validation logic here
            return null;
        }
    }


    public class ValidateEachItemAttribute : ValidationAttribute
    {
        protected readonly List<ValidationResult> validationResults = new List<ValidationResult>();
        public List<ModelErrorList> ModelErrorList = new List<ModelErrorList>();
        int skipCount = 0;
        public override bool IsValid(object value)
        {
            var list = value as IEnumerable;
            if (list == null) return true;

            var isValid = true;

            foreach (var item in list)
            {
                var validationContext = new ValidationContext(item);
                var isItemValid = Validator.TryValidateObject(item, validationContext, validationResults, true);

                if (!isItemValid)
                {
                    // خطاهای یک ردیف
                    var errorListInItemRow = validationResults.Skip(skipCount);
                    foreach (var itemerror in errorListInItemRow.ToList())
                    {
                        var personnelItem = item as PersonViewModel;
                        ModelErrorList.Add(new ModelErrorList
                        {
                            ItemId = personnelItem.Id,
                            RowId = personnelItem.ClientId,
                            FieldName = itemerror.MemberNames.FirstOrDefault(),
                            ErrorMessage = itemerror.ErrorMessage
                        });
                    }
                    skipCount += validationResults.Skip(skipCount).Count();

                }
                isValid &= isItemValid;
            }
            return isValid;
        }

        // I have ommitted error message formatting
    }



}