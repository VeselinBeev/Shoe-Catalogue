using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models.Shoe;

namespace Web.Controllers
{
    public class ShoeSizesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoeSizesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShoeSizes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShoeSize.ToListAsync());
        }

        // GET: ShoeSizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeSize = await _context.ShoeSize
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shoeSize == null)
            {
                return NotFound();
            }

            return View(shoeSize);
        }

        // GET: ShoeSizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoeSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Details,Type,Gender")] ShoeSize shoeSize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoeSize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoeSize);
        }

        // GET: ShoeSizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeSize = await _context.ShoeSize.SingleOrDefaultAsync(m => m.Id == id);
            if (shoeSize == null)
            {
                return NotFound();
            }
            return View(shoeSize);
        }

        // POST: ShoeSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Details,Type,Gender")] ShoeSize shoeSize)
        {
            if (id != shoeSize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoeSize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoeSizeExists(shoeSize.Id))
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
            return View(shoeSize);
        }

        // GET: ShoeSizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeSize = await _context.ShoeSize
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shoeSize == null)
            {
                return NotFound();
            }

            return View(shoeSize);
        }

        // POST: ShoeSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoeSize = await _context.ShoeSize.SingleOrDefaultAsync(m => m.Id == id);
            _context.ShoeSize.Remove(shoeSize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoeSizeExists(int id)
        {
            return _context.ShoeSize.Any(e => e.Id == id);
        }
    }
}
