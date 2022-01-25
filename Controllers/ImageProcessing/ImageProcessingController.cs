using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication12.Controllers.ImageProcessing
{
    public class ImageProcessingController : Controller
    {
        // GET: ImageProcessing
        public ActionResult IndexImagesProcessing()
        {
            return View();
        }


        [HttpPost]
        public System.Drawing.Image IndexImagesProcessing(string caption, System.Drawing.Image image1)
        {

            Debug.WriteLine("Holaaaaa image description: {0}", caption);
            
            
            return image1;
        }
    }
}