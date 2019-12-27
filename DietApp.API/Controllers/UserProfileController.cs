using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietApp.BusinessLogic.Interfaces;
using DietApp.DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DietApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }
        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile

        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var products = await _userProfileService.GetMealsAsync(userId);
            if (products == null)
                return BadRequest("Error");
            return Ok(products);
        }
    }
}