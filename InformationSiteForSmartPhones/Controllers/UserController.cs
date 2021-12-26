using InformationSiteForSmartPhones.Entities;
using InformationSiteForSmartPhones.Repositorites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InformationSiteForSmartPhones.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UserRepository repo = new UserRepository();
            List<User> items = repo.GetAll();

            ViewData["items"] = items;


            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            List<User> items = new List<User>();

            User user = null;

            if (id == null)
            {
                user = new User();
            }
            else
            {
                UserRepository repo = new UserRepository();
                user = repo.GetById(id.Value);
            }

            ViewData["item"] = user;


            return View();
        }
        [HttpPost]
        public ActionResult Edit(User item)
        {
            ViewData["item"] = item;

            bool isValid = true;

            if (string.IsNullOrEmpty(item.Username))
            {
                isValid = false;
                ViewData["usernameError"] = "This is required!";
            }
            if (string.IsNullOrEmpty(item.Password))
            {
                isValid = false;
                ViewData["passwordError"] = "This is required!";
            }
            if (string.IsNullOrEmpty(item.FirstName))
            {
                isValid = false;
                ViewData["FirstNameError"] = "This is required!";
            }
            if (string.IsNullOrEmpty(item.LastName))
            {
                isValid = false;
                ViewData["LastNameError"] = "This is required!";
            }

            if (isValid == false)
            {
                return View();
            }

            UserRepository repo = new UserRepository();
            repo.Save(item);

            return RedirectToAction("Index", "User");
        }


        public ActionResult Delete(int id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UserRepository repo = new UserRepository();
            repo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}