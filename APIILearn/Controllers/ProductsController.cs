using APIILearn.Model;
using APIILearn.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Security.Principal;

namespace APIILearn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]         // for all Controller
    public class ProductsController : Controller
    {
        private readonly DataCon con;

        public ProductsController(DataCon _con)
        {
            con = _con;
        }

        [HttpGet]
        [Route("")]
      
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var UserName = User.Identity?.Name;
            var UserId = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(con.Products.ToList());
        }

        [HttpGet]
        [Route("{key}")]                // Model Binding that let key in path see the id
        [AllowAnonymous]    // to allow Anonymous People for example (to allaw anonymous people to open login page)
        public ActionResult<Product> GetById([FromRoute (Name="key")] int id)
        {
            return Ok(con.Products.Find(id) == null ? NotFound() : Ok(con.Products.Find(id)));
        }


        [HttpPost]
        [Route("")]
        public ActionResult<int> CreateProduct(Product op) {

            con.Products.Add(op);
            con.SaveChanges();
            return Ok(op.ProductId);
        }

        [HttpPut]
        [Route("")]
        public ActionResult<int> UpdateProduct(Product op)
        {

            var oldpro = con.Products.Find(op.ProductId);
            oldpro.ProductName = op.ProductName;
            con.Products.Update(oldpro);
            con.SaveChanges();
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("")]
        public ActionResult<int>DeleteProduct(Product op)
        {
            con.Products.Remove(con.Products.Find(op.ProductId));
            con.SaveChanges();
            return Ok("Deleted Successfully");
        }
    }
}
