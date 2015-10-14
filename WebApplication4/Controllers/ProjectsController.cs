using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    [RequireHttps]
    public class ProjectsController : Controller
    {

        public ActionResult Projects()
        {
            return View();
        }
    }
}