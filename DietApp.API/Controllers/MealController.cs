using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly AuthenticationContext _context;
        public MealController(AuthenticationContext context, IMealService mealService)
        {
            _context = context;
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
        public async Task<ActionResult<Product>> PostMeal(Product meal)
        {
            _context.Products.Add(meal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeal", new { id = meal.Id }, meal);
        }

        // DELETE: api/Meal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteMeal(int id)
        {
            var meal = await _context.Products.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }

            _context.Products.Remove(meal);
            await _context.SaveChangesAsync();

            return meal;
        }

        private bool MealExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}