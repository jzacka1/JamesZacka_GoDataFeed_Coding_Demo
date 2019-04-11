using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JamesZacka_GoDataFeed_Coding_Demo.Models;
using JamesZacka_GoDataFeed_Coding_Demo.Services;

namespace JamesZacka_GoDataFeed_Coding_Demo.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private readonly Model1 _context;
        private readonly IProductService _productService;

        public ShoppingCartsController(Model1 context, ProductService productService)
        {
            this._productService = productService;
            _context = context;
        }

        // GET: ShoppingCarts
        public async Task<IActionResult> Index()
        {
            var model1 = _context.ShoppingCarts.Include(s => s.Customer);
            return View(await model1.ToListAsync());
        }

        // GET: ShoppingCarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCarts = await _context.ShoppingCarts
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shoppingCarts == null)
            {
                return NotFound();
            }

            return View(shoppingCarts);
        }

        // GET: ShoppingCarts/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "ID", "Name");
            return View();
        }

        //// POST: ShoppingCarts/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,CreatedDate,ModifiedDate,Total,CustomerId")] ShoppingCarts shoppingCarts)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(shoppingCarts);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    } 
        //    ViewData["CustomerId"] = new SelectList(_context.Customers, "ID", "Name", shoppingCarts.CustomerId);
        //    return View(shoppingCarts);
        //}

        // POST: ShoppingCarts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Quantity, ProductID")] CartItems cartItem, Products product)
        {
          var stuff = ViewBag.Product;
          ShoppingCarts shoppingCart = new ShoppingCarts();
          shoppingCart.CreatedDate = DateTime.Now;
          shoppingCart.ModifiedDate = DateTime.Now;
          shoppingCart.Total = cartItem.Quantity;

          return View(shoppingCart);
        }

    // GET: ShoppingCarts/Edit/5
    public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCarts = await _context.ShoppingCarts.FindAsync(id);
            if (shoppingCarts == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "ID", "Name", shoppingCarts.CustomerId);
            return View(shoppingCarts);
        }

        // POST: ShoppingCarts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CreatedDate,ModifiedDate,Total,CustomerId")] ShoppingCarts shoppingCarts)
        {
            if (id != shoppingCarts.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingCarts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingCartsExists(shoppingCarts.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "ID", "Name", shoppingCarts.CustomerId);
            return View(shoppingCarts);
        }

        // GET: ShoppingCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCarts = await _context.ShoppingCarts
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shoppingCarts == null)
            {
                return NotFound();
            }

            return View(shoppingCarts);
        }

        // POST: ShoppingCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingCarts = await _context.ShoppingCarts.FindAsync(id);
            _context.ShoppingCarts.Remove(shoppingCarts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingCartsExists(int id)
        {
            return _context.ShoppingCarts.Any(e => e.ID == id);
        }
    }
}
