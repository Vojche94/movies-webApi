using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Exceptions;
using MoviesApp.InterfaceModels.Enums;
using MoviesApp.InterfaceModels.Models;
using MoviesApp.Services.Implementations;
using MoviesApp.Services.Interfaces;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace MoviesApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        //private readonly MoviesService _moviesService;
        private readonly IMoviesService _moviesService;
        
        public MoviesController(IMoviesService movieService)
        {
            _moviesService = movieService;
        }
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public IActionResult GetAllMovies()
        {
            try
            {
                return Ok(_moviesService.GetAll());
            }
            catch(MoviesExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest($"Something went wrong contact support{ex}");
            }
        }
        [AllowAnonymous]
        [HttpGet("GetAllById/{id}")]
        public IActionResult GetAllMoviesById([FromRoute]int id)
        {
            
            try
            {
                //var userId = GetAuthorizedUserId();
                var response = _moviesService.GetById(id);
                return Ok(response);
            }
            catch (MoviesExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong contatc support{ex}");
            }
        }
        [AllowAnonymous]
        [HttpGet("GetAllByGenre/{genre}")]
        public IActionResult GetAllMoviesByGenre([FromRoute] int genre)
        {
            try
            {
                var response = _moviesService.GetByGenre(genre);
                return Ok(response);
            }
            catch(MoviesExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest("Something went wrong contact support");
            }
        }

        [HttpGet("GetAllByUserId")]
        public IActionResult GetAllMoviesByUserId()
        {
            try
            {
                var userId = GetAuthorizedUserId();
                var response = _moviesService.GetAllByUserId(userId).ToList();
                return Ok(response);
            }
            catch (MoviesExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong contact supprot{ex}");
            }
        }

        [HttpPost("Create")]
        public IActionResult CreateMovie([FromBody]MoviesModel model)
        {
            try
            {
                _moviesService.Create(model);
                return Ok();
            }
            catch(MoviesExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong contact support ");
            }
        }

        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteMovie([FromRoute] int id)
        {
            try
            {
                _moviesService.DeleteByid(id);
                return Ok($"Movie with id{id} was deleted");
            }
            catch(MoviesExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong contact support");
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateMovie([FromBody]MoviesModel model)
        {
            try
            {
                _moviesService.Update(model);
                return Ok("Movie was updated");
            }
            catch(MoviesExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong contact support");
            }
           
        }

      

        private int GetAuthorizedUserId()
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
            {
                string? name = User.FindFirst(ClaimTypes.Name)?.Value;
                throw new UserExceptions(userId, name, "Name identifier claim does not exist!");
            }
            return userId;
        }
    }
}
