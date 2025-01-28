using APILearn.Models;
using Microsoft.AspNetCore.Mvc;

namespace APILearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly DataCon con;
        public GenresController(DataCon con)
        {
            this.con = con;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var ret = await con.Genre.ToListAsync();
            return Ok(ret);
        }
    }
}
