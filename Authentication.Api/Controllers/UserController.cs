using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IService<User> _service;
        public UserController(IService<User> service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var entity = await _service.Get(id);
            return Ok();
        }
    }
}
