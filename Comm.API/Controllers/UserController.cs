using System;
using Comm.Model;
using Comm.Model.User;
using Comm.Service.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Comm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;
        public UserController(IUserService _userService, IMemoryCache _memoryCache)
        {
            userService = _userService;
            memoryCache = _memoryCache;
        }

        [HttpPost("/api/[controller]/register")]
        public Common<Model.User.User> Register([FromForm] User newUser)
        {
            return userService.Register(newUser);
        }

        [HttpPost("/api/[controller]/login")]
        public IActionResult Login([FromBody] UserLogin user)
        {
            var result = userService.Login(user);
            memoryCache.Set(key: "LoggedUser", result);
            return Ok(result.Entity);
        }
    }
}