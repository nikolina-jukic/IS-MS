using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MusicShopData;

namespace MusicShopBLL
{
	public static class Cart
	{

		public static async Task<bool> AddItemToCart(Artikl artikl, Korisnik korisnik, MSContext context)
		{
			try
			{
				ArtiklNarudzba artNar;
				Narudzba narudzba;

				var artNars = context.ArtiklNarudzbas.Where(a => a.SifArtikla == artikl.SifArtikla).Include(a => a.SifNarudzbeNavigation);

				if (artNars.Any())
				{
					artNar = artNars.First();
					narudzba = artNar.SifNarudzbeNavigation;
					artNar.Kolicina++;
					narudzba.Datum = DateTime.Now;

					context.Update(narudzba);
					context.Update(artNar);

				}
				else
				{
					narudzba = new Narudzba();
					narudzba.SifNarudzbe = context.Narudzbas.Count();
					narudzba.Username = korisnik.Username;
					narudzba.UsernameNavigation = korisnik;

					artNar = new ArtiklNarudzba();
					artNar.SifArtNar = context.ArtiklNarudzbas.Count();
					artNar.SifArtiklaNavigation = artikl;
					artNar.SifArtikla = artikl.SifArtikla;
					artNar.Kolicina = 1;
					artNar.SifNarudzbe = narudzba.SifNarudzbe;
					artNar.SifNarudzbeNavigation = narudzba;
					narudzba.Datum = DateTime.Now;

					context.Add(narudzba);
					context.Add(artNar);
				}

				await context.SaveChangesAsync();

				return true;
			}
			catch (Exception e)
			{
				return false;
			}

		}
	}
}
