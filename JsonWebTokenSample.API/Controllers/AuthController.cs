using JsonWebTokenSample.API.Models;
using JsonWebTokenSample.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JsonWebTokenSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> AccessToken(LoginDto loginDto)
        {
            var result = await _authService.SignInAsync(loginDto);

            return Ok(result);
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme) ]
        public async Task<IActionResult> Me()
        {
            var user = User.Identity.Name;

            return Ok(new { user = user, firstName = "Alican Çevik" });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [Route("adminpage")]
        public async Task<IActionResult> Admin()
        {
            var user = User.Identity.Name;

            return Ok(new { user = user, firstName = "Alican Çevik", pageTitle = "Admin" });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        [Route("userpage")]
        public async Task<IActionResult> UserPage()
        {
            var user = User.Identity.Name;

            return Ok(new { user = user, firstName = "Alican Çevik", pageTitle = "Admin" });
        }


    }
}
