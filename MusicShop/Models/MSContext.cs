using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MusicShop.Models
{
    public partial class MSContext : DbContext
    {
        public MSContext()
        {
        }

        public MSContext(DbContextOptions<MSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artikl> Artikls { get; set; }
        public virtual DbSet<ArtiklIzvodjac> ArtiklIzvodjacs { get; set; }
        public virtual DbSet<ArtiklNarudzba> ArtiklNarudzbas { get; set; }
        public virtual DbSet<ArtiklZanr> ArtiklZanrs { get; set; }
        public virtual DbSet<Izvodjac> Izvodjacs { get; set; }
        public virtual DbSet<Korisnik> Korisniks { get; set; }
        public virtual DbSet<Narudzba> Narudzbas { get; set; }
        public virtual DbSet<Recenzija> Recenzijas { get; set; }
        public virtual DbSet<VrstaArtikla> VrstaArtiklas { get; set; }
        public virtual DbSet<Zanr> Zanrs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-183QH3M\\SQLEXPRESS01;Initial Catalog=MS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Croatian_CI_AS");

            modelBuilder.Entity<Artikl>(entity =>
            {
                entity.HasKey(e => e.SifArtikla)
                    .HasName("PK__Artikl__F5366CB6A186E695");

                entity.ToTable("Artikl");

                entity.Property(e => e.SifArtikla)
                    .ValueGeneratedNever()
                    .HasColumnName("sifArtikla");

                entity.Property(e => e.Cijena).HasColumnName("cijena");

                entity.Property(e => e.Godina).HasColumnName("godina");

                entity.Property(e => e.Ime)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ime");

                entity.Property(e => e.SifVrste).HasColumnName("sifVrste");

                entity.HasOne(d => d.SifVrsteNavigation)
                    .WithMany(p => p.Artikls)
                    .HasForeignKey(d => d.SifVrste)
                    .HasConstraintName("FK__Artikl__sifVrste__35BCFE0A");
            });

            modelBuilder.Entity<ArtiklIzvodjac>(entity =>
            {
                entity.HasKey(e => e.SifAi)
                    .HasName("PK__ArtiklIz__3E8E7975041FB8DA");

                entity.ToTable("ArtiklIzvodjac");

                entity.Property(e => e.SifAi)
                    .ValueGeneratedNever()
                    .HasColumnName("sifAI");

                entity.Property(e => e.SifArtikla).HasColumnName("sifArtikla");

                entity.Property(e => e.SifIzvodjaca).HasColumnName("sifIzvodjaca");

                entity.HasOne(d => d.SifArtiklaNavigation)
                    .WithMany(p => p.ArtiklIzvodjacs)
                    .HasForeignKey(d => d.SifArtikla)
                    .HasConstraintName("FK__ArtiklIzv__sifIz__3C69FB99");

                entity.HasOne(d => d.SifIzvodjacaNavigation)
                    .WithMany(p => p.ArtiklIzvodjacs)
                    .HasForeignKey(d => d.SifIzvodjaca)
                    .HasConstraintName("FK__ArtiklIzv__sifIz__3D5E1FD2");
            });

            modelBuilder.Entity<ArtiklNarudzba>(entity =>
            {
                entity.HasKey(e => e.SifArtNar)
                    .HasName("PK__ArtiklNa__876305C7F801485C");

                entity.ToTable("ArtiklNarudzba");

                entity.Property(e => e.SifArtNar)
                    .ValueGeneratedNever()
                    .HasColumnName("sifArtNar");

                entity.Property(e => e.Kolicina).HasColumnName("kolicina");

                entity.Property(e => e.SifArtikla).HasColumnName("sifArtikla");

                entity.Property(e => e.SifNarudzbe).HasColumnName("sifNarudzbe");

                entity.HasOne(d => d.SifArtiklaNavigation)
                    .WithMany(p => p.ArtiklNarudzbas)
                    .HasForeignKey(d => d.SifArtikla)
                    .HasConstraintName("FK__ArtiklNar__kolic__412EB0B6");

                entity.HasOne(d => d.SifNarudzbeNavigation)
                    .WithMany(p => p.ArtiklNarudzbas)
                    .HasForeignKey(d => d.SifNarudzbe)
                    .HasConstraintName("FK__ArtiklNar__sifNa__4222D4EF");
            });

            modelBuilder.Entity<ArtiklZanr>(entity =>
            {
                entity.HasKey(e => e.SifAz)
                    .HasName("PK__ArtiklZa__3E8E799A2C73A860");

                entity.ToTable("ArtiklZanr");

                entity.Property(e => e.SifAz)
                    .ValueGeneratedNever()
                    .HasColumnName("sifAZ");

                entity.Property(e => e.SifArtikla).HasColumnName("sifArtikla");

                entity.Property(e => e.SifZanra).HasColumnName("sifZanra");

                entity.HasOne(d => d.SifArtiklaNavigation)
                    .WithMany(p => p.ArtiklZanrs)
                    .HasForeignKey(d => d.SifArtikla)
                    .HasConstraintName("FK__ArtiklZan__sifZa__38996AB5");

                entity.HasOne(d => d.SifZanraNavigation)
                    .WithMany(p => p.ArtiklZanrs)
                    .HasForeignKey(d => d.SifZanra)
                    .HasConstraintName("FK__ArtiklZan__sifZa__398D8EEE");
            });

            modelBuilder.Entity<Izvodjac>(entity =>
            {
                entity.HasKey(e => e.SifIzvodjaca)
                    .HasName("PK__Izvodjac__524EB2CFABA1B084");

                entity.ToTable("Izvodjac");

                entity.Property(e => e.SifIzvodjaca)
                    .ValueGeneratedNever()
                    .HasColumnName("sifIzvodjaca");

                entity.Property(e => e.PunoIme)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("punoIme");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Korisnik__F3DBC5731DA70F43");

                entity.ToTable("Korisnik");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Adresa)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("adresa");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ime");

                entity.Property(e => e.Lozinka)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("lozinka");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("prezime");
            });

            modelBuilder.Entity<Narudzba>(entity =>
            {
                entity.HasKey(e => e.SifNarudzbe)
                    .HasName("PK__Narudzba__DEB6F4AAAA112588");

                entity.ToTable("Narudzba");

                entity.Property(e => e.SifNarudzbe)
                    .ValueGeneratedNever()
                    .HasColumnName("sifNarudzbe");

                entity.Property(e => e.Datum)
                    .HasColumnType("datetime")
                    .HasColumnName("datum");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Narudzbas)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__Narudzba__userna__3E52440B");
            });

            modelBuilder.Entity<Recenzija>(entity =>
            {
                entity.HasKey(e => e.SifRecenzije)
                    .HasName("PK__Recenzij__D3D5BC066905E41E");

                entity.ToTable("Recenzija");

                entity.Property(e => e.SifRecenzije)
                    .ValueGeneratedNever()
                    .HasColumnName("sifRecenzije");

                entity.Property(e => e.SifArtikla).HasColumnName("sifArtikla");

                entity.Property(e => e.Tekst)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("tekst");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.SifArtiklaNavigation)
                    .WithMany(p => p.Recenzijas)
                    .HasForeignKey(d => d.SifArtikla)
                    .HasConstraintName("FK__Recenzija__sifAr__34C8D9D1");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Recenzijas)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__Recenzija__usern__267ABA7A");
            });

            modelBuilder.Entity<VrstaArtikla>(entity =>
            {
                entity.HasKey(e => e.SifVrste)
                    .HasName("PK__VrstaArt__F8B96843FC8D50C7");

                entity.ToTable("VrstaArtikla");

                entity.Property(e => e.SifVrste)
                    .ValueGeneratedNever()
                    .HasColumnName("sifVrste");

                entity.Property(e => e.ImeVrste)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("imeVrste");
            });

            modelBuilder.Entity<Zanr>(entity =>
            {
                entity.HasKey(e => e.SifZanra)
                    .HasName("PK__Zanr__1FB7EF48432E8D65");

                entity.ToTable("Zanr");

                entity.Property(e => e.SifZanra)
                    .ValueGeneratedNever()
                    .HasColumnName("sifZanra");

                entity.Property(e => e.Ime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
