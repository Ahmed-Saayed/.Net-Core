using APIILearn.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIILearn.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            return Ok(con.Products.ToList());
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<IEnumerable<Product>> GetById(int id)
        {
            return Ok(con.Products.Find(id) == null ? NotFound() : Ok(con.Products.Find(id)));
        }


        [HttpPost]
        [Route("{id}")]
        public ActionResult<int> CreateProduct(Product op) {

            op.ProductId = 0;
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
        [Route("id")]
        public ActionResult<int>DeleteProduct(Product op)
        {
            con.Products.Remove(con.Products.Find(op.ProductId));
            con.SaveChanges();
            return Ok("Deleted Successfully");
        }
    }
}
