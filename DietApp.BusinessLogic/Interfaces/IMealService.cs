using DietApp.BusinessLogic.DTOs;
using DietApp.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.BusinessLogic.Interfaces
{
    public interface IMealService
    {
        Task<IEnumerable<ProductDto>> GetMealsAsync();
        Task PostMealAsync(ProductDto product);
        Task<ProductDto> DeleteMealAsync(int id);
    }
}
