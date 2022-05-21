﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShopData;

namespace MusicShopBLL
{
	public class NarudzbaViewModel
	{
		private double? _cijena;

		public NarudzbaViewModel(int sifNar, int? kolicina, DateTime? datum, string? ime, double? cijena)
		{
			this.sifNar = sifNar;
			this.Kolicina = kolicina;
			this.Datum = datum;
			this.Ime = ime;
			this.Cijena = cijena;
		}

		public int sifNar { get; private set; }

		public int? Kolicina { get; private set; }

		public DateTime? Datum { get; private set; }

		public string? Ime { get; private set; }

		public double? Cijena { get => _cijena * Kolicina;
			private set => _cijena = value;
		}

		public bool Detail { get; set; } = false;

		public Artikl Artikl { get; set; } = null;
	}
}
