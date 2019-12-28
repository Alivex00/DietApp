using AutoMapper;
using DietApp.BusinessLogic.DTOs;
using DietApp.BusinessLogic.Interfaces;
using DietApp.DataAccessLayer.Interfaces;
using DietApp.DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace DietApp.BusinessLogic.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _appSettings;

        public ApplicationUserService(IMapper mapper, IDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        public async Task PostUserAsync(ApplicationUserDto model)
        {
            var mappedModel = _mapper.Map<ApplicationUserModel>(model);
            mappedModel.Role = "Customer";
            var applicationUser = new ApplicationUser()
            {
                UserName = mappedModel.UserName,
                Email = mappedModel.Email,
                Fullname = mappedModel.FullName
            };
            try
            {
                var result = await _userManager.CreateAsync(applicationUser, mappedModel.Password);
                await _userManager.AddToRoleAsync(applicationUser, mappedModel.Role);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> LoginAsync(LoginDto model)
        {
            var mappedModel = _mapper.Map<LoginModel>(model);
            var user = await _userManager.FindByNameAsync(mappedModel.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, mappedModel.Password))
            {
                //get user role
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return token;
                
            }
            else
                return null;
        }
    }
}
