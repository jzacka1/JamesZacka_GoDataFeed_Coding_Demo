using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JamesZacka_GoDataFeed_Coding_Demo.Models;

namespace JamesZacka_GoDataFeed_Coding_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsAPIController : ControllerBase
    {
        private readonly Model1 _context;

        public ShoppingCartsAPIController(Model1 context)
        {
            _context = context;
        }

        // GET: api/ShoppingCartsAPI
        [HttpGet]
        public IEnumerable<ShoppingCarts> GetShoppingCarts()
        {
            return _context.ShoppingCarts;
        }

        // GET: api/ShoppingCartsAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoppingCarts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shoppingCarts = await _context.ShoppingCarts.FindAsync(id);

            if (shoppingCarts == null)
            {
                return NotFound();
            }

            return Ok(shoppingCarts);
        }

        // PUT: api/ShoppingCartsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingCarts([FromRoute] int id, [FromBody] ShoppingCarts shoppingCarts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shoppingCarts.ID)
            {
                return BadRequest();
            }

            _context.Entry(shoppingCarts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingCartsExists(id))
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

        // POST: api/ShoppingCartsAPI
        [HttpPost]
        public async Task<IActionResult> PostShoppingCarts([FromBody] ShoppingCarts shoppingCarts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ShoppingCarts.Add(shoppingCarts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingCarts", new { id = shoppingCarts.ID }, shoppingCarts);
        }

        // DELETE: api/ShoppingCartsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingCarts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shoppingCarts = await _context.ShoppingCarts.FindAsync(id);
            if (shoppingCarts == null)
            {
                return NotFound();
            }

            _context.ShoppingCarts.Remove(shoppingCarts);
            await _context.SaveChangesAsync();

            return Ok(shoppingCarts);
        }

        private bool ShoppingCartsExists(int id)
        {
            return _context.ShoppingCarts.Any(e => e.ID == id);
        }
    }
}