using DietApp.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.BusinessLogic.Interfaces
{
    public interface IApplicationUserService
    {
        Task PostUserAsync(ApplicationUserDto model);
        Task<string> LoginAsync(LoginDto model);
    }
}
