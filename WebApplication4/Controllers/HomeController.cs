using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(string From, string Subject, string Body)
        {
            var username = ConfigurationManager.AppSettings["SendGridUserName"];
            var password = ConfigurationManager.AppSettings["SendGridPassword"];
            var from = ConfigurationManager.AppSettings["ContactEmail"];

            SendGridMessage myMessage = new SendGridMessage();
            myMessage.AddTo("keith.sturzenbecker@gmail.com");
            myMessage.From = new MailAddress(From);
            myMessage.Subject = Subject;
            myMessage.Html = Body;

            var credentials = new NetworkCredential(username, password);

            var transportWeb = new Web(credentials);

            transportWeb.DeliverAsync(myMessage);

            return RedirectToAction("Contact");
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