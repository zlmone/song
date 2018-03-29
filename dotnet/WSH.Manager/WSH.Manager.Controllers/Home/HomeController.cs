using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WSH.Manager.Controllers.Home
{
    public class HomeController : BaseController
    {
        public ActionResult Login() {
            return View();
        }
        public ActionResult Index() {
            return View();
        }
        public ActionResult _Top() {
            return View();
        }
    }
}   
