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
    public class CartController : Controller
    {
        private readonly MSContext _context;

        public CartController(MSContext context)
        {
            _context = context;
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            List<NarudzbaViewModel> narudzbe = new List<NarudzbaViewModel>();
            var korisnik = _context.Korisniks.First();
            var artNars = _context.ArtiklNarudzbas.Where(n => n.SifNarudzbeNavigation.Username == korisnik.Username).Include(n => n.SifArtiklaNavigation).Include(n => n.SifNarudzbeNavigation);
            foreach(var artNar in artNars)
			{
                NarudzbaViewModel narudzbaViewModel = new NarudzbaViewModel(
                    artNar.SifArtNar,
                    artNar.Kolicina,
                    artNar.SifNarudzbeNavigation.Datum,
                    artNar.SifArtiklaNavigation.Ime,
                    artNar.SifArtiklaNavigation.Cijena,
                    artNar.SifArtiklaNavigation);
                narudzbe.Add(narudzbaViewModel);
			}

            return View(narudzbe);
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narudzba = await _context.Narudzbas
                .Include(n => n.UsernameNavigation)
                .FirstOrDefaultAsync(m => m.SifNarudzbe == id);
            if (narudzba == null)
            {
                return NotFound();
            }

            return View(narudzba);
        }

        // POST: Cart/Delete/5
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artNar = await _context.ArtiklNarudzbas
                .Include(n => n.SifNarudzbeNavigation)
                .Include(n => n.SifArtiklaNavigation)
                .FirstOrDefaultAsync(m => m.SifArtNar == id);
            if (artNar == null)
            {
                return NotFound();
            }

            _context.ArtiklNarudzbas.Remove(artNar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Order()
        {

            var artNars = _context.ArtiklNarudzbas
                .Include(n => n.SifNarudzbeNavigation)
                .Include(n => n.SifArtiklaNavigation);

            foreach (var artNar in artNars)
			{
                _context.ArtiklNarudzbas.Remove(artNar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        private bool NarudzbaExists(int id)
        {
            return _context.Narudzbas.Any(e => e.SifNarudzbe == id);
        }
    }
}
