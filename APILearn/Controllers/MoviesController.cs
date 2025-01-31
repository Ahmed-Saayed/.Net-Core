using APILearn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly DataCon _con;
        private readonly List<string> allowed_Extension = new List<string>() { ".png", ".jpg" };
        public MoviesController(DataCon con)
        {
            _con = con;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_con.Movies.OrderByDescending(o => o.Rate).ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie_Details(int id)
        {
            var ret = _con.Movies.Find(id);

            if (ret == null)
                return NotFound();

            return Ok(ret);
        }


        [HttpGet("Get_By_GenId")]
        public async Task<IActionResult> GetMovie_Details2(int id)
        {
            var ret = _con.Movies.Where(o => o.GenIdForeign == 1).ToList();

            return Ok(ret);
        }

        [HttpPost]
        public async Task<IActionResult> Create_Movie([FromForm] Create_Movie mv)
        {
            if (!allowed_Extension.Contains(Path.GetExtension(mv.Poster.FileName).ToLower()))
                return BadRequest("Only .png and .jpg Images allowed");

            if (_con.Genre.Find(mv.GenIdForeign) == null)
                return BadRequest("Not Found Genre");

            using var stream = new MemoryStream();
            await mv.Poster.CopyToAsync(stream);

            var new_movie = new Movie
            {
                Title = mv.Title,
                Rate = mv.Rate,
                Poster = stream.ToArray(),
                StoreLine = mv.StoreLine,
                GenIdForeign = mv.GenIdForeign
            };

            await _con.AddAsync(new_movie);
            _con.SaveChanges();

            return Ok(new_movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update_Movie(int id,[FromForm]Create_Movie upmv)
        {
            var mv = _con.Movies.Find(id);
            if (mv == null)
                return NotFound($"No Movie With id {id}");

            if (_con.Genre.Find(upmv.GenIdForeign) == null)
                return NotFound("Not Found Genre");

            if (!allowed_Extension.Contains(Path.GetExtension(upmv.Poster.FileName).ToLower()))
                return BadRequest("Only .png and .jpg Images allowed");

            using var stream = new MemoryStream();
            await upmv.Poster.CopyToAsync(stream);

            mv.Title = upmv.Title;
            mv.Rate = upmv.Rate;
            mv.Poster = stream.ToArray();
            mv.StoreLine = upmv.StoreLine;
            mv.GenIdForeign = upmv.GenIdForeign;

            _con.SaveChanges();

            return Ok($"Movie with id equal to {id} updated");
        }
      
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var mv = _con.Movies.Find(id);
            if (mv == null)
                return NotFound("NotFound The Movie");

            _con.Movies.Remove(mv);
            _con.SaveChanges();

            return Ok(mv);
        }
    }
}
