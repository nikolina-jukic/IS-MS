using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicShopData;
using MusicShopBLL;

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
        public async Task<IActionResult> Index(string searchStr)
        {
            var artikli = from a in _context.Artikls select a;

            if (!String.IsNullOrEmpty(searchStr))
            {
                artikli = artikli.Where(s => s.Ime.Contains(searchStr));
            }

            return View(await artikli.ToListAsync());
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

        public async Task<IActionResult> AddToCart(int? id)
        {
            if (id == null)
            {
                System.Diagnostics.Debug.WriteLine("Not found!");
                return NotFound();
            }
            var artikl = await _context.Artikls.FindAsync(id);
            if (artikl == null)
            {
                System.Diagnostics.Debug.WriteLine("Not found!");
                return NotFound();
            }

            Korisnik korisnik = _context.Korisniks.First();

            if(await Cart.AddItemToCart(artikl, korisnik, _context)){
                System.Diagnostics.Debug.WriteLine("Success!");
			}
			else
			{
                System.Diagnostics.Debug.WriteLine("Failure!");
            }

            return RedirectToAction("Index");

        }

        // GET: Artikls/Create
        public IActionResult Create()
        {
            ViewData["SifVrste"] = new SelectList(_context.VrstaArtiklas, "SifVrste", "ImeVrste");
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
                artikl.SifArtikla = NewId();
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
            ViewData["SifVrste"] = new SelectList(_context.VrstaArtiklas, "SifVrste", "ImeVrste", artikl.SifVrste);
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
                return RedirectToAction(nameof(Details), new { id = id});
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

        private int NewId()
        {
            var maxId = _context.Artikls
                      .Select(o => o.SifArtikla)
                      .ToList()
                      .Max();

            return maxId + 1;
        }
    }
}
