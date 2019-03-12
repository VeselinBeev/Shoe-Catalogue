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
    public class ShoeCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoeCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShoeCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShoeCategory.ToListAsync());
        }

        // GET: ShoeCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeCategory = await _context.ShoeCategory
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shoeCategory == null)
            {
                return NotFound();
            }

            return View(shoeCategory);
        }

        // GET: ShoeCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoeCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ShoeCategory shoeCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoeCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoeCategory);
        }

        // GET: ShoeCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeCategory = await _context.ShoeCategory.SingleOrDefaultAsync(m => m.Id == id);
            if (shoeCategory == null)
            {
                return NotFound();
            }
            return View(shoeCategory);
        }

        // POST: ShoeCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ShoeCategory shoeCategory)
        {
            if (id != shoeCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoeCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoeCategoryExists(shoeCategory.Id))
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
            return View(shoeCategory);
        }

        // GET: ShoeCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeCategory = await _context.ShoeCategory
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shoeCategory == null)
            {
                return NotFound();
            }

            return View(shoeCategory);
        }

        // POST: ShoeCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoeCategory = await _context.ShoeCategory.SingleOrDefaultAsync(m => m.Id == id);
            _context.ShoeCategory.Remove(shoeCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoeCategoryExists(int id)
        {
            return _context.ShoeCategory.Any(e => e.Id == id);
        }
    }
}
