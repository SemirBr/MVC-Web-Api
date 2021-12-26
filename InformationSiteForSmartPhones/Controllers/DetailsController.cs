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
    public class DetailsController :Controller
    {

        [AuthenticationFilter]
        // GET: SmartphonesDetails
        public ActionResult Index()
        {
            User loggedUser = (User)Session["loggedUser"];

            DetailsRepository repo = new DetailsRepository();
            List<SmartPhonesDetails> item = repo.GetAll(loggedUser.Id);
            ViewData["item"] = item;

            return View();
        }

    }
}