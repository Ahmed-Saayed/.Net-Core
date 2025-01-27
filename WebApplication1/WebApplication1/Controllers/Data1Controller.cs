using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModel;
namespace WebApplication1.Controllers
{
    public class Data1Controller : Controller
    {
        Datacon op = new Datacon();
        public IActionResult Index()
        {
            List<Department> dp = op.Departments.ToList();
            //Search for Inculde to get Departments with Their Students

            //return View("Index",dp);   //View=Index ,Model dp
            //return View(dp);           //View=Index ,Model dp
            //return View();             //View=Index ,Model null
            //return View("Index");      //View=Index ,Model null
            return View(dp);
        }

        //=================================================================
        public IActionResult Index2()
        {
            List<string> items = new List<string>();
            items.Add("TV");
            items.Add("Wach");
            items.Add("Ps4");
            items.Add("club");

            string col = "red",name = "PATO";
            int temp = 44;
            
            //ViewData must do casting in View file but ViewBag not

            ViewData["Tempreature"] = temp;
            ViewData["listt"] = items;
            ViewBag.colour = col;

            return View();
        }

        
        public IActionResult Index3()
        {
            List<string> items = new List<string>();
            items.Add("TV");
            items.Add("Wach");
            items.Add("Ps4");
            items.Add("club");

            string col = "violet", name = "PATO";
            int temp = 44;

            //ViewData must do casting in View file but ViewBag not

            ViewData["Tempreature"] = temp;
            ViewData["listt"] = items;
            ViewBag.colour = col;


            TestViewModel op = new TestViewModel();
            op.color = col;
            op.Items = items;
            op.Name = name;
            return View(op);

            // ViewModel  :Class data need to send to View      
            //add extra info
            //merge between 2 Model
            // filter property 
        }


        //=================================================================
        //Cockies video 6 
        public IActionResult SetTempData() {
            TempData["msg"] = "Message Hellow";
            return Content("Data saved");
        }
        public IActionResult GetTempData()
        {
            string ret = "Empty message";
            if (TempData.ContainsKey("msg"))
            {
                  ret = TempData["msg"].ToString();
                //ret = TempData.Peek("msg").ToString();  // Peek dont delete it after set

                //TempData.Keep();        keep it dont delete any tempdata
                //TempData.Keep("sadf");  keep it dont delete this spasific tempdata

            }
            return Content(ret);
        }
        public IActionResult SetSession() {                     // can get from any controller
            HttpContext.Session.SetString("Ahmed", "PATO");
            HttpContext.Session.SetInt32("age", 21);

            return Content("Set Done");
        }
        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("Ahmed");
            int age =HttpContext.Session.GetInt32("age").Value; //.Value to get value becuse GetInt allaow null  or make int? ___

            return Content($"data name ={name}   age = {age}");
        }
        public IActionResult SetCookies()                   // can get from any controller
        {
            CookieOptions options = new CookieOptions();

            options.Expires = DateTimeOffset.Now.AddHours(1);

            Response.Cookies.Append("Ahmed", "PATO", options);
            Response.Cookies.Append("age", "21");

            return Content("Cookies Done");
        }
        public IActionResult GetCookies()
        {
            string name = Request.Cookies["Ahmed"];
            int age = int.Parse(Request.Cookies["age"]);

            return Content($"From cookies  {name} {age}");
        }

        //=================================================================

        //Model Binding :Map Action Parametere with request data (FormData - QueryString - RouteData) Video 7
        // URL Data1/TestPrimitive?id=3&name=ahmed&age=21&age=21&colo[1]=red&colo[0]=blue
        public IActionResult TestPrimitive(int id, string name,int age,string[] colo)
        {
            return Content($"ID = {id}  Name = {name} age = {age}");
        }

        // URL Data1/Collection?name=Ahmed&phone[ahmed]=321&phone[pato]=123
        public IActionResult Collection(Dictionary<string,int>phone, string name)
        {
            return Content($"Name = {name}  phone[ahmed]= {phone["ahmed"]}   phone[pato]= {phone["PATO"]}   ");
        }

        // URL Data1/TestComplex?
        //Data1/TestComplex?vec_st[0].name=ahmed&vec_st[0].id=1&vec_st[1].name=pato&vec_st[1].id=2&name=toto
        public IActionResult TestComplex(Department dep)    //([Bind(include:"Id,Name")]Department dep) for Filter onlyyou want to bind
        {
            return Content("Saved Done");
        }

        //=================================================================

        IStudents_properties stpro = new Students_properties(); // Why use interface? To Make Dependency Inversion Principle  video row 3 last video min 40
        public IActionResult JoinUs() {
            List<Students> lst = stpro.Get_All();
            return View(lst);
        }
        
        // Anchor tag open empty form
        // Submit
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

        // Submit Button==>store data in database
        // to didnt add the row from link
        [HttpPost]
        public IActionResult SaveData(Students st)
        {
            if (ModelState.IsValid)
            {
                stpro.Insert(st);
                return RedirectToAction("JoinUs");  //RedirectToAction  becuse view JoinUs return object
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
                
                return RedirectToAction("JoinUs");  //RedirectToAction  becuse view JoinUs return object
            }
            else
            {
                ViewData["deplst"] = op.Departments.ToList();
                return View("Edit", st);
            }
        }
    }
}