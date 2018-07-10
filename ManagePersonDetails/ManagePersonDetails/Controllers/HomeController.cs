using ManagePersonDetails.BAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagePersonDetails.Models;
using ManagePersonDetails.Utilities;

namespace ManagePersonDetails.Controllers
{
    [LogFilter]
    [HandleError]
    public class HomeController : Controller
    {
        //GET: Home
        public ActionResult Index()
        {
            try
            {
                PersonManager manger = new PersonManager();
                Person person = new Person();
                Criteria criteria = new Criteria();
                person.ListPerson = manger.ListPerson(criteria);
                return View(person);

            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
           
        }

        //GET: AddPersonView
        public ActionResult Add(PersonReport personDetails)
        {
            return View("Add");
        }

        //GET: EditPersonView
        public ActionResult Edit()
        {
            PersonManager manger = new PersonManager();
            Person person = new Person();
            Criteria criteria = new Criteria();

            if (Helper.IsNullOrEmpty(Convert.ToString(Request.QueryString["pid"])) == false)
            {
                long personID = Convert.ToInt64(Request.QueryString["pid"]);

                if (personID > 0)
                {
                    criteria.PersonID = personID;
                    person.ListPerson = manger.ListPerson(criteria);                    
                }                
            }
            else
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            return View(person);
        }                
        
        [HttpPost]
        public JsonResult AddPerson(PersonReport person)
        {
            PersonManager manager = null;
            bool isAdded = false;

            try
            {
                manager = new PersonManager();
                isAdded = manager.AddPerson(person);
            }
            catch (Exception ex)
            {
                throw;
            }

            return Json(isAdded, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdatePerson(PersonReport person)
        {
            PersonManager manager = null;
            bool isAdded = false;

            try
            {
                manager = new PersonManager();
                isAdded = manager.UpdatePerson(person);
            }
            catch (Exception ex)
            {
                throw;
            }

            return Json(isAdded, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdatePersonStatus(PersonReport personDetails)
        {
            PersonManager manager = null;
            bool isAdded = false;

            try
            {
                manager = new PersonManager();
                isAdded = manager.UpdatePersonStatus(personDetails);

            }
            catch (Exception ex)
            {
                throw;
            }

            return Json(isAdded, JsonRequestBehavior.AllowGet);
        }
    }
}
