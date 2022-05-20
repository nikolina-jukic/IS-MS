using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicShopData;

namespace MusicShop.Controllers
{
    public class ZanrsController : Controller
    {
        private readonly MSContext _context;

        public ZanrsController(MSContext context)
        {
            _context = context;
        }

        // GET: Zanrs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zanrs.ToListAsync());
        }

        // GET: Zanrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanr = await _context.Zanrs
                .FirstOrDefaultAsync(m => m.SifZanra == id);
            if (zanr == null)
            {
                return NotFound();
            }

            return View(zanr);
        }

        // GET: Zanrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zanrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SifZanra,Ime")] Zanr zanr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zanr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zanr);
        }

        // GET: Zanrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanr = await _context.Zanrs.FindAsync(id);
            if (zanr == null)
            {
                return NotFound();
            }
            return View(zanr);
        }

        // POST: Zanrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SifZanra,Ime")] Zanr zanr)
        {
            if (id != zanr.SifZanra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zanr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZanrExists(zanr.SifZanra))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = id});
            }
            return View(zanr);
        }

        // GET: Zanrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanr = await _context.Zanrs
                .FirstOrDefaultAsync(m => m.SifZanra == id);
            if (zanr == null)
            {
                return NotFound();
            }

            return View(zanr);
        }

        // POST: Zanrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zanr = await _context.Zanrs.FindAsync(id);
            _context.Zanrs.Remove(zanr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZanrExists(int id)
        {
            return _context.Zanrs.Any(e => e.SifZanra == id);
        }
    }
}
