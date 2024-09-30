using api_fameza.Models;
using api_fameza.Models.Request;
using api_fameza.Models.Responses;
using api_fameza.Security;
using Azure;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_fameza.Controllers
{
    [Route("/api/v1/auth/")]
    [ApiController]
    [EnableCors("ReglasCors")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private IAuthService _authService = authService;

        private DataResponse<User> dataResponseUser = new DataResponse<User>();
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] AuthRequest authRequest)
        {
            var dataResponseUser = await _authService.findByEmail(authRequest);

            if (dataResponseUser.Data == null)
            {
                return NotFound(new
                {
                    dataResponseUser!.StatusCode,
                    dataResponseUser.Error,
                    dataResponseUser.Message,
                    dataResponseUser.Success
                });
            }
            if (dataResponseUser.Data != null && dataResponseUser.Success == false)
            {
                return Unauthorized(new
                {
                    dataResponseUser!.StatusCode,
                    dataResponseUser.Error,
                    dataResponseUser.Message,
                    dataResponseUser.Success
                });
            }

            return Ok(new
            {
                dataResponseUser.StatusCode, 
                dataResponseUser.Message,
                dataResponseUser.Success,
                dataResponseUser.Data
            });
        }


    }
}
