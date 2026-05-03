using Microsoft.AspNetCore.Mvc;
namespace TP_Modul10_103022430014
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private static List<Film> dataFilm = new List<Film>
        {
            new Film("Inception", "Christopher Nolan", "2010", "Sci-Fi", "9.0"),
            new Film("Interstellar", "Christopher Nolan", "2014", "Sci-Fi", "8.7"),
            new Film("Parasite", "Bong Joon-ho", "2019", "Thriller", "8.6")
        };

        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return dataFilm;
        }
        [HttpGet("{id}")]
        public ActionResult<Film> Get(int id)
        {
            if (id < 0 || id >= dataFilm.Count) return NotFound();
            return dataFilm[id];
        }

        [HttpPost]
        public IActionResult Post([FromBody] Film newFilm)
        {
            dataFilm.Add(newFilm);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= dataFilm.Count) return NotFound();
            dataFilm.RemoveAt(id);
            return Ok();
        }
    }
}
