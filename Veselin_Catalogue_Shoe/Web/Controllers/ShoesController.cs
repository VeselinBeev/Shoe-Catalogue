using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    public class ShoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shoe.ToListAsync());
        }

        // GET: Shoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // GET: Shoes/Create
        public IActionResult Create()
        {
            var categories = GetCategories().Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });
            ViewBag.Categories = categories;

            return View();
        }

        // POST: Shoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Category")] ShoeViewModel shoeViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoryId = Int32.Parse(shoeViewModel.Category);

                var shoe = new Shoe
                {
                    Name = shoeViewModel.Name,
                    Price = shoeViewModel.Price,
                    Category = _context.ShoeCategory.First(e => e.Id == categoryId)
                };

            _context.Add(shoe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
            return View(shoeViewModel);
    }

    // GET: Shoes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var shoe = await _context.Shoe.SingleOrDefaultAsync(m => m.Id == id);
        if (shoe == null)
        {
            return NotFound();
        }
        return View(shoe);
    }

    // POST: Shoes/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Shoe shoe)
    {
        if (id != shoe.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(shoe);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoeExists(shoe.Id))
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
        return View(shoe);
    }

    // GET: Shoes/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var shoe = await _context.Shoe
            .SingleOrDefaultAsync(m => m.Id == id);
        if (shoe == null)
        {
            return NotFound();
        }

        return View(shoe);
    }

    // POST: Shoes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var shoe = await _context.Shoe.SingleOrDefaultAsync(m => m.Id == id);
        _context.Shoe.Remove(shoe);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ShoeExists(int id)
    {
        return _context.Shoe.Any(e => e.Id == id);
    }

    public IEnumerable<ShoeCategory> GetCategories()
    {
        var categories = _context.ShoeCategory.ToList();

        return categories;
    }
}
}
