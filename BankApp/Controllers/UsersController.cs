using BankApp.Application.Common.Interfaces;
using BankApp.Application.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) => _userService = userService;

        // POST api/<UsersController>
        [HttpPost("auth")]
        public IActionResult Post([FromBody] AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            if (response == null)
            {
                return BadRequest(new
                {
                    message = "Username or password are incorrect"
                });
            }
            return Ok(response);
        }
    }
}
