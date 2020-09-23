using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QCMApp.Controllers
{
    public class ElementController : Controller
    {
        // GET: Element
        public ActionResult PageCreateDescription()
        {
            return View();
        }
        public ActionResult PageCreateQuestion()
        {
            return View();
        }
    }
}