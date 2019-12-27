using AutoMapper;
using DietApp.BusinessLogic.DTOs;
using DietApp.BusinessLogic.Interfaces;
using DietApp.DataAccessLayer.Interfaces;
using DietApp.DataAccessLayer.Models;
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

        public async Task PostMealAsync(ProductDto meal)
        {
            var mappedMeal = _mapper.Map<Product>(meal);
            _context.Products.Add(mappedMeal);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductDto> DeleteMealAsync(int id)
        {
            var meal = await _context.Products.FindAsync(id);
            var mappedMeal = _mapper.Map<ProductDto>(meal);
            _context.Products.Remove(meal);
            await _context.SaveChangesAsync();
            return mappedMeal;


        }
    }
}
