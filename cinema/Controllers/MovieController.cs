using cinema.Models;
using cinema.Services;
using Microsoft.AspNetCore.Mvc;
using Twilio.Types;
using Twilio;

namespace cinema.Controllers
{
    [Route("api/movie")]
    public class MovieController : Controller
    {
        public MovieService movieService;
        public MovieController(MovieService _movieService)
        {
            this.movieService = _movieService;
        }

        [HttpGet("findAll")]
        [Produces("application/json")]
        public IActionResult findAll(string date, int cinemaId)
        {
          
            try
            {
                return Ok(movieService.findAll(true, date, cinemaId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("findAllByStatus")]
        [Produces("application/json")]
        public IActionResult findAll()
        {
            try
            {
                return Ok(movieService.findAll(true));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("findMovieById/{id}")]
        [Produces("application/json")]
        public IActionResult findMovieById(int id)
        {
            try
            {
                return Ok(movieService.findById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("findMovie")]
        [Produces("application/json")]
        public IActionResult findMovie(string date, int cinemaId, int movieId)
        {
            try
            {
                return Ok(movieService.findMovie(true, date, cinemaId, movieId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult create([FromBody] Movie movie)
        {
            movie.Status = true;
            
            try
            {
                return Ok(new
                {
                    Status = movieService.create(movie)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        [Produces("application/json")]
        public IActionResult delete(int id)
        {
            var movie = movieService.findById1(id);
            movie.Status = false;
            try
            {
                return Ok(new
                {
                    Status = movieService.update(movie)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult edit([FromBody] Movie movie)

        {
            movie.Status = true;
            try
            {
                return Ok(new
                {
                    Status = movieService.update(movie)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
