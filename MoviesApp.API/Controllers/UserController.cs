using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using MoviesApp.Exceptions;
using MoviesApp.InterfaceModels.Models;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var response = _userService.GetAllUsers();
                return Ok(response);
            }
            catch(UserExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest("Something went wrong contact support");
            }
        }
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody]LoginModel model)
        {
            try
            {
                var response = _userService.Authenticate(model.Username, model.Password);
                return Ok(response);
            }
            catch(UserExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong cotnact supp");
            }
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody]RegisterModel model)
        {
            try
            {
                _userService.Register(model);
                return Ok("User registered sucessfully");
            }
            catch(UserExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong contac support");
            }

        }
    }
}
