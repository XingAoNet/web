using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XingAo.Software.Web.Manager.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult LogOn()
        {
            return View();
        }

        public ActionResult LogOut()
        {

            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

    }
}
