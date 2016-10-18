using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace CreoPro.Controllers
{
    public class MemberController : Controller
    {
        creo_dataEntities db;

        public MemberController() {
            db = new creo_dataEntities();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Detail()
        {
            ViewData["member"] = db.member.ToList();
            return View();
        }

    }
}
