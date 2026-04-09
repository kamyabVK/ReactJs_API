using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reactjs_api.Model;

namespace Reactjs_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new List<UserDetail>
        {
            new UserDetail { UserId = 1, UserEmailId = "vinit@gmail.com", UserName = "Vinit" },
            new UserDetail { UserId = 2, UserEmailId = "rahul@gmail.com", UserName = "Rahul" },
            new UserDetail { UserId = 3, UserEmailId = "aman@gmail.com", UserName = "Aman" }
        };

            return Ok(users);
        }
    }
}
