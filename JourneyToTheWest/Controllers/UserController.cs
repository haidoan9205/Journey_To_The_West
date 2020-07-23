using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JourneyToTheWest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly jwwtContext _context;
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public UserController(IAuthRepository authRepo, IConfiguration config, jwwtContext context)
        {
            //_userLogic = userLogic;
            _context = context;
            _repo = authRepo;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto user)
        {
            var userFromData = await _repo.Login(user.UserId.ToLower(), user.Password);
            if (userFromData == null)
                return Unauthorized();
            return Ok(user);
        }
    }
}
