using System;
using Comm.API.Infrastructure;
using Comm.Model.User;
using Comm.Service.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Comm.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;
        public UserController(IUserService _userService, IMemoryCache _memoryCache)
        {
            userService = _userService;
            memoryCache = _memoryCache;
        }

        [HttpGet("/[controller]/register")]
        public IActionResult RegisterForm()
        {
            return View();
        }

        [HttpPost("/[controller]/register")]
        public IActionResult Register([FromForm] User newUser)
        {
            var result = userService.Register(newUser);
            return Redirect("/User/login");
        }

        [HttpGet("/[controller]/login")]
        public IActionResult LoginForm()
        {
            return View();
        }

        [HttpPost("/[controller]/login")]
        public Comm.Model.Common<Model.User.User> Login([FromForm] UserLogin user)
        {
            var result = userService.Login(user);
            memoryCache.Set(key: "LoggedUser", result);
            return result;
        }
    }
}