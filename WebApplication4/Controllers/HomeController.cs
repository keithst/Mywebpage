using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Resume()
        {
            return File("~/App_Data/KeithSturzenbeckerResume.pdf", "application/pdf");
        }

        public ActionResult PhotoGallery()
        {
            return View();
        }

    }
}