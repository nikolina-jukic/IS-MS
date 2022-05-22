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
    public class VrstaArtiklasController : Controller
    {
        private readonly MSContext _context;

        public VrstaArtiklasController(MSContext context)
        {
            _context = context;
        }

        // GET: VrstaArtiklas
        public async Task<IActionResult> Index(string searchStr)
        {
            var vrste = from a in _context.VrstaArtiklas select a;

            if (!String.IsNullOrEmpty(searchStr))
            {
                vrste = vrste.Where(s => s.ImeVrste.Contains(searchStr));
            }

            return View(await vrste.ToListAsync());
        }

        // GET: VrstaArtiklas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vrstaArtikla = await _context.VrstaArtiklas
                .FirstOrDefaultAsync(m => m.SifVrste == id);
            if (vrstaArtikla == null)
            {
                return NotFound();
            }

            return View(vrstaArtikla);
        }

        // GET: VrstaArtiklas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VrstaArtiklas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SifVrste,ImeVrste")] VrstaArtikla vrstaArtikla)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    vrstaArtikla.SifVrste = NewId();
                    _context.Add(vrstaArtikla);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return View(vrstaArtikla);
        }

        // GET: VrstaArtiklas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vrstaArtikla = await _context.VrstaArtiklas.FindAsync(id);
            if (vrstaArtikla == null)
            {
                return NotFound();
            }
            return View(vrstaArtikla);
        }

        // POST: VrstaArtiklas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SifVrste,ImeVrste")] VrstaArtikla vrstaArtikla)
        {
            if (id != vrstaArtikla.SifVrste)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vrstaArtikla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VrstaArtiklaExists(vrstaArtikla.SifVrste))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = id });
            }
            return View(vrstaArtikla);
        }

        // GET: VrstaArtiklas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vrstaArtikla = await _context.VrstaArtiklas
                .FirstOrDefaultAsync(m => m.SifVrste == id);
            if (vrstaArtikla == null)
            {
                return NotFound();
            }

            return View(vrstaArtikla);
        }

        // POST: VrstaArtiklas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vrstaArtikla = await _context.VrstaArtiklas.FindAsync(id);
            _context.VrstaArtiklas.Remove(vrstaArtikla);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VrstaArtiklaExists(int id)
        {
            return _context.VrstaArtiklas.Any(e => e.SifVrste == id);
        }

        private int NewId()
        {
            var maxId = _context.Zanrs
                      .Select(o => o.SifZanra)
                      .ToList()
                      .Max();

            return maxId + 1;
        }
    }
}
