using APILearn.Models;
using Microsoft.AspNetCore.Mvc;

namespace APILearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenre_Services op;
        public GenresController(IGenre_Services _op)
        {
            op = _op;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lstofgen = await op.Get_All();
            return Ok(lstofgen);
        }

        [HttpGet("GetId/{id}")]
        public IActionResult GetById(int id)
        {
            if (op.Get_Genre_ById(id) == null)
                return NotFound("NOT Found The Genre");

            return  Ok(op.Get_Genre_ById(id));
        }

       
        [HttpGet("GetMoviesByGenId/{id}")]
        public IActionResult GetMoviesByGenId(int id)
        {
            if (op.Get_Genre_ById(id) == null)
                return NotFound("NOT Found The Genre");

            return Ok(op.GetMoviesOfGere(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Genre gen)
        {
            var addgen = op.Add_Genre(gen);

            return Ok(gen);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody]Genre gen)
        {
            var Upgenn = op.Get_Genre_ById(id);
            if (Upgenn == null)
                return NotFound($"No Genre Found here with id {id}");
            
            return Ok(op.Update_Genre(id, gen));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Delgenn = op.Get_Genre_ById(id);
            if (Delgenn == null)
                return NotFound($"No Genre Found here with id {id}");
            
            return Ok(op.Delete_Genre(id));
        }

    }
}
