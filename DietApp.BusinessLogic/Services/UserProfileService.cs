using AutoMapper;
using DietApp.BusinessLogic.DTOs;
using DietApp.BusinessLogic.Interfaces;
using DietApp.DataAccessLayer.Interfaces;
using DietApp.DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.BusinessLogic.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        public UserProfileService(IMapper mapper, IDbContext context, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApplicationUserDto> GetUsersAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var mappedUser = _mapper.Map<ApplicationUserDto>(user);
            return mappedUser;

        }
    }
}
