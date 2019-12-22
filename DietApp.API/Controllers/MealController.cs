using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly AuthenticationContext _context;
        public MealController(AuthenticationContext context)
        {
            _context = context;
        }
        // GET: api/Meal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetMeals()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Meal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetMeal(int id)
        {
            var meal = await _context.Products.FindAsync(id);

            if (meal == null)
            {
                return NotFound();
            }

            return meal;
        }

        // PUT: api/Meal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmeal(int id, Product meal)
        {
            if (id != meal.Id)
            {
                return BadRequest();
            }

            _context.Entry(meal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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