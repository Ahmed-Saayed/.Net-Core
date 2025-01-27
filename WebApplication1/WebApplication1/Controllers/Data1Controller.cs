using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class Data1Controller : Controller
    {
        Datacon op = new Datacon();
        IStudents_properties stpro = new Students_properties();
        public IActionResult JoinUs() {
            List<Students> lst = stpro.Get_All();
            return View(lst);
        }
        

        public IActionResult SignUp(){
            ViewData["deplst"] = op.Departments.ToList();
            return View(new Students());// form Sign
        }
        public IActionResult Edit(int id)
        {
            Students st = stpro.GetByID(id);
            ViewData["deplst"] = op.Departments.ToList();
            return View(st);            // form Edit
        }

        [HttpPost]
        public IActionResult SaveData(Students st)
        {
            if (ModelState.IsValid)
            {
                stpro.Insert(st);
                return RedirectToAction("JoinUs");
            }
            else
            {
                ViewData["deplst"] = op.Departments.ToList();
                return View("SignUp",st);
            }
        }

        [HttpPost]
        public IActionResult SaveData2(int id ,Students st)
        {
            if (ModelState.IsValid)
            {
                stpro.Update(id, st);
                
                return RedirectToAction("JoinUs");
            }
            else
            {
                ViewData["deplst"] = op.Departments.ToList();
                return View("Edit", st);
            }
        }
    }
}