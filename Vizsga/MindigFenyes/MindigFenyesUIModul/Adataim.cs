using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MindigFenyesUIModul;

public partial class Adataim : DbContext
{
    public Adataim()
    {
    }

    public Adataim(DbContextOptions<Adataim> options)
        : base(options)
    {
    }

    public virtual DbSet<Bejelentesek> Bejelenteseks { get; set; }

    public virtual DbSet<FeladatTipusok> FeladatTipusoks { get; set; }

    public virtual DbSet<Feladatok> Feladatoks { get; set; }

    public virtual DbSet<Munka> Munkas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\gabser\\OneDrive - ASSA ABLOY Group\\Documents\\Webuni\\Vizsga\\MindigFenyes\\mindigfenyes.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bejelentesek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bejelent__3214EC0719223AEA");

            entity.ToTable("Bejelentesek");

            entity.Property(e => e.Cim)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Idopont).HasColumnType("date");
        });

        modelBuilder.Entity<FeladatTipusok>(entity =>
        {
            entity.HasKey(e => e.TipusId).HasName("PK__FeladatT__CDF975A66010FB37");

            entity.ToTable("FeladatTipusok");

            entity.Property(e => e.FeladatTipus)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<Feladatok>(entity =>
        {
            entity.HasKey(e => e.FeladatId).HasName("PK__tmp_ms_x__650313C8B5CCC9CE");

            entity.ToTable("Feladatok");

            entity.Property(e => e.BefejezDatum).HasColumnType("datetime");
            entity.Property(e => e.BejDatum).HasColumnType("datetime");
            entity.Property(e => e.Helyszin)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Leiras)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Szerelo)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Tipus)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<Munka>(entity =>
        {
            entity.HasKey(e => e.MunkasId).HasName("PK__tmp_ms_x__EB12AFC575B6D262");

            entity.Property(e => e.Nev)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.SzulDatum).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
