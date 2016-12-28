using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace CreoPro.Controllers
{
    public class HomeController : Controller
    {
        creo_dataEntities db;

        public HomeController()
        {
            db = new creo_dataEntities();
        }


        public ActionResult Index()
        {
            ViewData.Model = db.member.EntitySet;
            ViewBag.Model1 = db.member.ToList();

            string[] items = new string[] { "one", "two", "three" };
            ViewBag.Items = items;

            BLL.member bll_mem = new BLL.member();
            Model.member model_mem = new member();
            model_mem = bll_mem.GetModel(1);


            return View(model_mem);
        }

        [HttpPost]
        public ActionResult HelloModelTest(Model.member model)
        {
            string name = model.userName;
            string text = model.userPwd;
            return View();
        }

    }
}
