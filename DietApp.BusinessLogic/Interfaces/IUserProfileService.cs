using DietApp.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.BusinessLogic.Interfaces
{
    public interface IUserProfileService
    {
        Task<ApplicationUserDto> GetUsersAsync(string userId);
    }
}
