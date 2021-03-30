using Domain.Dtos.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_Products_pagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJwtToken _jwt;

        public LoginController(IJwtToken jwt)
        {
            _jwt = jwt;
        }
        // POST api/<LoginController>
        [HttpPost, AllowAnonymous]
        public IActionResult Post([FromBody] UserLogin user)
        {
            if (user == null)
            {
                return Unauthorized();
            }
            if (user.name != UserInfo.name || user.password != UserInfo.password)
            {
                return Unauthorized();
            }

            return Ok(new { token = _jwt.Generate(user)});
        }
    }
    static class UserInfo
    {
        public static string name = "Vuducvi";
        public static string password = "123456";
    }
}
