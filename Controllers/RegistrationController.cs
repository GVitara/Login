using LoginAPI.Interface;
using LoginAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class RegistrationController : ControllerBase
    {

        private readonly IRegisterService _registerService;

        public RegistrationController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("InCorrect Details");
                }
                bool check = await _registerService.RegisterUser(user);

                return check ? Ok("Register Successfully") : Ok("Something wrong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
