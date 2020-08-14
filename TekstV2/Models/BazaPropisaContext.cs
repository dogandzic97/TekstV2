using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TekstV2.Models
{
    public partial class BazaPropisaContext : DbContext
    {
        public BazaPropisaContext()
        {
        }

        public BazaPropisaContext(DbContextOptions<BazaPropisaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clan> Clan { get; set; }
        public virtual DbSet<Glava> Glava { get; set; }
        public virtual DbSet<NivoVazenjaPropisa> NivoVazenjaPropisa { get; set; }
        public virtual DbSet<Podpodrubrika> Podpodrubrika { get; set; }
        public virtual DbSet<Podrubrika> Podrubrika { get; set; }
        public virtual DbSet<Propis> Propis { get; set; }
        public virtual DbSet<Rubrika> Rubrika { get; set; }
        public virtual DbSet<Stav> Stav { get; set; }
        public virtual DbSet<Tacka> Tacka { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DLHDK3B\\MSSQLSERVER01;Database=BazaPropisa;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clan>(entity =>
            {
                entity.HasOne(d => d.IdGlavaNavigation)
                    .WithMany(p => p.Clan)
                    .HasForeignKey(d => d.IdGlava)
                    .HasConstraintName("FK_Clan_Glava");

                entity.HasOne(d => d.IdPropisNavigation)
                    .WithMany(p => p.Clan)
                    .HasForeignKey(d => d.IdPropis)
                    .HasConstraintName("FK_Clan_Propis");
            });

            modelBuilder.Entity<Glava>(entity =>
            {
                entity.HasOne(d => d.IdPropisaNavigation)
                    .WithMany(p => p.Glava)
                    .HasForeignKey(d => d.IdPropisa)
                    .HasConstraintName("FK_Glava_Propis");
            });

            modelBuilder.Entity<NivoVazenjaPropisa>(entity =>
            {
                entity.Property(e => e.Naziv).HasMaxLength(255);
            });

            modelBuilder.Entity<Podpodrubrika>(entity =>
            {
                entity.HasOne(d => d.IdPodrubrikeNavigation)
                    .WithMany(p => p.Podpodrubrika)
                    .HasForeignKey(d => d.IdPodrubrike)
                    .HasConstraintName("FK_Podpodrubrika_Podrubrika");
            });

            modelBuilder.Entity<Podrubrika>(entity =>
            {
                entity.HasOne(d => d.IdRubrikaNavigation)
                    .WithMany(p => p.Podrubrika)
                    .HasForeignKey(d => d.IdRubrika)
                    .HasConstraintName("FK_Podrubrika_Rubrika");
            });

            modelBuilder.Entity<Propis>(entity =>
            {
                entity.Property(e => e.DatumObjavljivanja).HasMaxLength(50);

                entity.Property(e => e.DatumPocetkaPrimene).HasMaxLength(50);

                entity.Property(e => e.DatumPrestankaPropisa).HasMaxLength(50);

                entity.Property(e => e.DatumPrestankaVerzije).HasMaxLength(50);

                entity.Property(e => e.DatumSns).HasMaxLength(50);

                entity.Property(e => e.DatumSnsOsnovnogTekstaPropisa).HasMaxLength(50);

                entity.Property(e => e.GlasiloDatum).HasMaxLength(50);

                entity.Property(e => e.OblastDelatnost).HasMaxLength(255);

                entity.HasOne(d => d.IdNivoaNavigation)
                    .WithMany(p => p.Propis)
                    .HasForeignKey(d => d.IdNivoa)
                    .HasConstraintName("FK_Propis_NivoVazenjaPropisa");

                entity.HasOne(d => d.IdPodpodrubrikaNavigation)
                    .WithMany(p => p.Propis)
                    .HasForeignKey(d => d.IdPodpodrubrika)
                    .HasConstraintName("FK_Propis_Podpodrubrika");

                entity.HasOne(d => d.IdPordrubrikaNavigation)
                    .WithMany(p => p.Propis)
                    .HasForeignKey(d => d.IdPordrubrika)
                    .HasConstraintName("FK_Propis_Podrubrika");

                entity.HasOne(d => d.IdRubrikaNavigation)
                    .WithMany(p => p.Propis)
                    .HasForeignKey(d => d.IdRubrika)
                    .HasConstraintName("FK_Propis_Rubrika");
            });

            modelBuilder.Entity<Stav>(entity =>
            {
                entity.HasOne(d => d.IdClanNavigation)
                    .WithMany(p => p.Stav)
                    .HasForeignKey(d => d.IdClan)
                    .HasConstraintName("FK_Stav_Clan");
            });

            modelBuilder.Entity<Tacka>(entity =>
            {
                entity.HasOne(d => d.IdStavNavigation)
                    .WithMany(p => p.Tacka)
                    .HasForeignKey(d => d.IdStav)
                    .HasConstraintName("FK_Tacka_Stav");
            });
        }
    }
}
