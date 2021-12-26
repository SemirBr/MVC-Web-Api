using InformationSiteForSmartPhones.Entities;
using InformationSiteForSmartPhones.Filters;
using InformationSiteForSmartPhones.Repositorites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InformationSiteForSmartPhones.Controllers
{
    public class SmartPhonesController : Controller
    {
        [AuthenticationFilter]
        // GET: Smartphones
        public ActionResult Index()
        {
            User loggedUser = (User)Session["loggedUser"];

            SmartPhonesRepository repo = new SmartPhonesRepository();
            List<SmartPhones> item = repo.GetAll(loggedUser.Id);

            ViewData["item"] = item;

            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            List<SmartPhones> item = new List<SmartPhones>();

            SmartPhones user = null;

            if (id == null)
            {
                user = new SmartPhones();
            }
            else
            {
                SmartPhonesRepository repo = new SmartPhonesRepository();
                user = repo.GetById(id.Value);
            }

            ViewData["item"] = user;


            return View();
        }
        
        [HttpPost]
        public ActionResult Edit(SmartPhones item)
        {
            ViewData["item"] = item;

            bool isValid = true;

            if (string.IsNullOrEmpty(item.Manufacturer))
            {
                isValid = false;
                ViewData["manufacturerError"] = "This is required!";
            }
            if (string.IsNullOrEmpty(item.Model))
            {
                isValid = false;
                ViewData["modelError"] = "This is required!";
            }
            if (string.IsNullOrEmpty(item.InteralMemory))
            {
                isValid = false;
                ViewData["InteralMemoryError"] = "This is required!";
            }
            if (string.IsNullOrEmpty(item.RamMemory))
            {
                isValid = false;
                ViewData["RamMemoryError"] = "This is required!";
            }
            if (string.IsNullOrEmpty(item.ResolutionOfCamera))
            {
                isValid = false;
                ViewData["ResolutionOfCameraError"] = "This is required!";
            }

            if (isValid == false)
            {
                return View();
            }

            SmartPhonesRepository repo = new SmartPhonesRepository();
            repo.Save(item);

            return RedirectToAction("Index", "SmartPhones");
        }
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SmartPhones item)
        {
            User loggedUser = (User)Session["loggedUser"];

            SmartPhonesRepository repo = new SmartPhonesRepository();
            repo.Save(item);


            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            User loggedUser = (User)Session["loggedUser"];

            SmartPhonesRepository repo = new SmartPhonesRepository();
            repo.Delete(id);


            return RedirectToAction("Index");

        }
        
    }
}