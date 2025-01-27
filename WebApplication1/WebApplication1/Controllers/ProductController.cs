using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {

        // action cant overload

        //   this way instead of writhe controller name and action name and parametar
        //   [Route("/pro/{msg:Alpha}")]
        //    customize the wirtten URl   Vedio 4 row 3 min 46

        public IActionResult print(string msg)
        {
            return Content("go");
        }

        public ContentResult contentprint()
        {
            ContentResult op1 = new ContentResult();
            op1.Content = "Local msg";
            return op1;
        }

        public ViewResult viewprint()
        {          // create file with controller name in view then add view 
            /*ViewResult op1 = new ViewResult();
            op1.ViewName = "View1";
            return op1;*/
            return View("View1");
        }

        public JsonResult jsprint()
        {
            return Json(new { ID = 1, name = "PATO" });
        }

        // Product/ShowMix?id=22&&age=5    with any action parameter 

        public IActionResult ShowMix(int id, int age)
        {
            if (id % 3 == 0)
            {
                return Content("Local msg2");
            }
            else
            {
                return View("My View 2");
            }
        }

        public ActionResult details()
        {
            //Model
            ProductSampleData samdat = new ProductSampleData();
            List<Product> lst= samdat.v;
            //Send View

            return View("ProDetails", lst);
        }

        //=================================================================================
        //=================================================================================

    }
}
