using InformationSiteForSmartPhones.Repositorites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InformationSiteForSmartPhones.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(string username, string password)
        {

            UserRepository repo = new UserRepository();
            Session["loggedUser"] = repo.GetUsernameAndPassword(username, password);


            if (Session["loggedUser"] != null)
                return RedirectToAction("Index", "Home");


            ViewData["username"] = username;
            ViewData["password"] = password;

            bool isValid = true;

            if (username == "")
            {
                isValid = false;
                ViewData["usernameError"] = "This field is required!";
            }
            if (password == "")
            {
                isValid = false;
                ViewData["passwordError"] = "This field is required!";
            }

            if (isValid == false)
                return View();



            if (Session["loggedUser"] == null)
            {
                isValid = false;
                ViewData["authErr"] = "Authentication Failed!";

            }

            if (isValid == false)
                return View();



            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Session["loggedUser"] = null;
            return RedirectToAction("Login", "Home");
        }
    }
}