using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietApp.BusinessLogic.DTOs;
using DietApp.BusinessLogic.Interfaces;
using DietApp.DataAccessLayer;
using DietApp.DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;
        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }
        // GET: api/Meal
        [HttpGet]
        public async Task<IActionResult> GetMeals()
        {
            var products = await _mealService.GetMealsAsync();
            if (products == null)
                return BadRequest("Error");
            return Ok(products);
        }

        // POST: api/Meal
        [HttpPost]
        public async Task<IActionResult> PostMeal(ProductDto meal)
        {
            await _mealService.PostMealAsync(meal);

            return Ok();
        }

        // DELETE: api/Meal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            var meal = await _mealService.DeleteMealAsync(id);
            if (meal == null)
            {
                return NotFound();
            }
            return Ok(meal);
        }

    }
}