using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApplication12.Models.Coffee;

namespace WebApplication12.Controllers.Coffee
{
    public class CoffeeController : Controller
    {
        // GET: Coffee
        public ActionResult Create()
        {
            return View(new CoffeeViewModel());
        }



        [HttpPost]
        public ActionResult Create(CoffeeViewModel eventmodel)
        {
            if (ModelState.IsValid)
            {
                var path = Path.Combine(Server.MapPath("~/Images"));
                eventmodel.ImageUpload.SaveAs("C:/Proyectos/phtree_test/WebApplication12/Images/bbbb1.png");

                eventmodel.imagePath = "~/Images/bbbb1.png";

                return RedirectToAction("ViewCoffee", eventmodel);
            }
            return View(eventmodel);
        }


        public ActionResult ViewCoffee(CoffeeViewModel eventmodel)
        {
            return View(eventmodel);
        }
    }
}
