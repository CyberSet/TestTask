using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class citizensController : Controller
    {
        private readonly citizensContext _context;

        public citizensController(citizensContext context)
        {
            _context = context;
        }

        // GET: citizens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Citizens.ToListAsync());
        }

        // GET: citizens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizens = await _context.Citizens
                .FirstOrDefaultAsync(m => m.id == id);
            if (citizens == null)
            {
                return NotFound();
            }

            return View(citizens);
        }

        // GET: citizens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: citizens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,sex,age")] citizens citizens)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citizens);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(citizens);
        }

        // GET: citizens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizens = await _context.Citizens.FindAsync(id);
            if (citizens == null)
            {
                return NotFound();
            }
            return View(citizens);
        }

        // POST: citizens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,name,sex,age")] citizens citizens)
        {
            if (id != citizens.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citizens);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!citizensExists(citizens.id))
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
            return View(citizens);
        }

        // GET: citizens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizens = await _context.Citizens
                .FirstOrDefaultAsync(m => m.id == id);
            if (citizens == null)
            {
                return NotFound();
            }

            return View(citizens);
        }

        // POST: citizens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var citizens = await _context.Citizens.FindAsync(id);
            _context.Citizens.Remove(citizens);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool citizensExists(string id)
        {
            return _context.Citizens.Any(e => e.id == id);
        }
    }
}
