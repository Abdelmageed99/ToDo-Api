using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models.CustomModels;
using TestAPI.Models.DomainModels.UserManagement.DTO;
using TestAPI.Services.AuthManagement;

namespace TestAPI.Controllers
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

        [HttpPost("Register")]
        public async Task<ActionResult<AuthModel>> RegisterAsync(RegisterModel model)
        {
            

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Massage);
            }
            
       
            return Ok(result);
            
            
        }

        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync(LoginModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var result = await _authService.LoginAsync(model);

            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Massage);
            }

            return Ok(result);
        }

    }
}
