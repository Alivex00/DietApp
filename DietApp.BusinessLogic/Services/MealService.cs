using AutoMapper;
using DietApp.BusinessLogic.DTOs;
using DietApp.BusinessLogic.Interfaces;
using DietApp.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.BusinessLogic.Services
{
    public class MealService : IMealService
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _context;
        public MealService(IMapper mapper, IDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetMealsAsync()
        {
            var products = await _context.Products.ToListAsync();
            var mappedProducts = _mapper.Map<List<ProductDto>>(products);
            return mappedProducts;
        }

        public async Task<IEnumerable<ProductDto>> PostMealAsync(ProductDto meal)
        {
            var mappedMeal - _mapper.Map<Product>
            await _context.Products.Add(meal);
            await _context.Products.SaveChangesAsync();
        }
    }
}
