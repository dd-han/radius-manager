using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RadiusManager.Models;

namespace RadiusManager.Controllers
{
    public class RadCheckController : Controller
    {
        private readonly DatabaseContext _context;

        public RadCheckController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: RadCheck
        public async Task<IActionResult> Index()
        {
            return View(await _context.RadCheck.ToListAsync());
        }

        // GET: RadCheck/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radCheck = await _context.RadCheck
                .FirstOrDefaultAsync(m => m.Id == id);
            if (radCheck == null)
            {
                return NotFound();
            }

            return View(radCheck);
        }

        // GET: RadCheck/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RadCheck/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Attribute,Op,Value")] RadCheck radCheck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(radCheck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(radCheck);
        }

        // GET: RadCheck/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radCheck = await _context.RadCheck.FindAsync(id);
            if (radCheck == null)
            {
                return NotFound();
            }
            return View(radCheck);
        }

        // POST: RadCheck/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Username,Attribute,Op,Value")] RadCheck radCheck)
        {
            if (id != radCheck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(radCheck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RadCheckExists(radCheck.Id))
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
            return View(radCheck);
        }

        // GET: RadCheck/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radCheck = await _context.RadCheck
                .FirstOrDefaultAsync(m => m.Id == id);
            if (radCheck == null)
            {
                return NotFound();
            }

            return View(radCheck);
        }

        // POST: RadCheck/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var radCheck = await _context.RadCheck.FindAsync(id);
            _context.RadCheck.Remove(radCheck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RadCheckExists(uint id)
        {
            return _context.RadCheck.Any(e => e.Id == id);
        }
    }
}
