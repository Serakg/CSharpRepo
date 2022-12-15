using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MindigFenyesWebModul;

public partial class Bejelenteseim : DbContext
{
    public Bejelenteseim()
    {
    }

    public Bejelenteseim(DbContextOptions<Bejelenteseim> options)
        : base(options)
    {
    }

    public virtual DbSet<Bejelentesek> Bejelenteseks { get; set; }

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
            entity.Property(e => e.Idopont).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
