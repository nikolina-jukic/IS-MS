using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicShop.Models;

namespace MusicShop.Controllers
{
    public class ArtiklsController : Controller
    {
        private readonly MSContext _context;

        public ArtiklsController(MSContext context)
        {
            _context = context;
        }

        // GET: Artikls
        public async Task<IActionResult> Index()
        {
            var mSContext = _context.Artikls.Include(a => a.SifVrsteNavigation);
            return View(await mSContext.ToListAsync());
        }

        // GET: Artikls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikl = await _context.Artikls
                .Include(a => a.SifVrsteNavigation)
                .FirstOrDefaultAsync(m => m.SifArtikla == id);
            if (artikl == null)
            {
                return NotFound();
            }

            return View(artikl);
        }

        // GET: Artikls/Create
        public IActionResult Create()
        {
            ViewData["SifVrste"] = new SelectList(_context.VrstaArtiklas, "SifVrste", "SifVrste");
            return View();
        }

        // POST: Artikls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SifArtikla,Ime,SifVrste,Godina,Cijena")] Artikl artikl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artikl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SifVrste"] = new SelectList(_context.VrstaArtiklas, "SifVrste", "SifVrste", artikl.SifVrste);
            return View(artikl);
        }

        // GET: Artikls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikl = await _context.Artikls.FindAsync(id);
            if (artikl == null)
            {
                return NotFound();
            }
            ViewData["SifVrste"] = new SelectList(_context.VrstaArtiklas, "SifVrste", "SifVrste", artikl.SifVrste);
            return View(artikl);
        }

        // POST: Artikls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SifArtikla,Ime,SifVrste,Godina,Cijena")] Artikl artikl)
        {
            if (id != artikl.SifArtikla)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artikl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtiklExists(artikl.SifArtikla))
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
            ViewData["SifVrste"] = new SelectList(_context.VrstaArtiklas, "SifVrste", "SifVrste", artikl.SifVrste);
            return View(artikl);
        }

        // GET: Artikls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikl = await _context.Artikls
                .Include(a => a.SifVrsteNavigation)
                .FirstOrDefaultAsync(m => m.SifArtikla == id);
            if (artikl == null)
            {
                return NotFound();
            }

            return View(artikl);
        }

        // POST: Artikls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artikl = await _context.Artikls.FindAsync(id);
            _context.Artikls.Remove(artikl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtiklExists(int id)
        {
            return _context.Artikls.Any(e => e.SifArtikla == id);
        }
    }
}
