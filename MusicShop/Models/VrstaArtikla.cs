using System;
using System.Collections.Generic;

#nullable disable

namespace MusicShop.Models
{
    public partial class VrstaArtikla
    {
        public VrstaArtikla()
        {
            Artikls = new HashSet<Artikl>();
        }

        public int SifVrste { get; set; }
        public string ImeVrste { get; set; }

        public virtual ICollection<Artikl> Artikls { get; set; }
    }
}
