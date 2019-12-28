using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DietApp.BusinessLogic.DTOs;
using DietApp.BusinessLogic.Interfaces;
using DietApp.DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DietApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserService _applicationUserService;

        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }
        [HttpPost]
        [Route("Register")]
        //POST : /api/ApplicationUser/Register
        public async Task<IActionResult> PostUser(ApplicationUserDto user)
        {
            await _applicationUserService.PostUserAsync(user);

            return Ok();
        }
        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> Login(LoginDto user)
        {
            var result = await _applicationUserService.LoginAsync(user);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }  
    }
}