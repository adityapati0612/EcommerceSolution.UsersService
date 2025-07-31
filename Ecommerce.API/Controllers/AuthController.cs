using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        //[Route("register")] //api/Auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            //check for invalid register request
            if (registerRequest == null)
            {
                return BadRequest("Invalid User Registeration");
            }
            //call the UsersService to handle registeration
            AuthenticationResponse? authenticationResponse=await userService.Register(registerRequest);

            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                return BadRequest(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null)
                return BadRequest("Invalid Login");

            AuthenticationResponse? authenticationResponse= await userService.Login(loginRequest);

            if(authenticationResponse == null || authenticationResponse.Success == false)
                { return Unauthorized(authenticationResponse); }

            return Ok(authenticationResponse);
        }
    }
}
