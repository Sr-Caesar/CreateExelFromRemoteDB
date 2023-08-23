using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExelFlightSheet.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aereo> Aereo { get; set; }

    public virtual DbSet<Aeroporto> Aeroporto { get; set; }

    public virtual DbSet<Volo> Volo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("MyDbConnectionyy");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aereo>(entity =>
        {
            entity.HasKey(e => e.Tipoaereo).HasName("PK__AEREO__7AEDE68E2AF46B11");

            entity.ToTable("AEREO");

            entity.Property(e => e.Tipoaereo)
                .HasMaxLength(6)
                .HasColumnName("TIPOAEREO");
            entity.Property(e => e.Numpasseggeri).HasColumnName("NUMPASSEGGERI");
            entity.Property(e => e.Qntmerci).HasColumnName("QNTMERCI");
        });

        modelBuilder.Entity<Aeroporto>(entity =>
        {
            entity.HasKey(e => e.Citta).HasName("PK__AEROPORT__A2DAF123ED00ED11");

            entity.ToTable("AEROPORTO");

            entity.Property(e => e.Citta)
                .HasMaxLength(20)
                .HasColumnName("CITTA");
            entity.Property(e => e.Nazione)
                .HasMaxLength(3)
                .HasColumnName("NAZIONE");
            entity.Property(e => e.Numpiste).HasColumnName("NUMPISTE");
        });

        modelBuilder.Entity<Volo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VOLO__3214EC27E6B31F05");

            entity.ToTable("VOLO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cittaarr)
                .HasMaxLength(20)
                .HasColumnName("CITTAARR");
            entity.Property(e => e.Cittapart)
                .HasMaxLength(20)
                .HasColumnName("CITTAPART");
            entity.Property(e => e.Giornosett)
                .HasColumnType("datetime")
                .HasColumnName("GIORNOSETT");
            entity.Property(e => e.Idvolo)
                .HasMaxLength(10)
                .HasColumnName("IDVOLO");
            entity.Property(e => e.Oraarr)
                .HasColumnType("datetime")
                .HasColumnName("ORAARR");
            entity.Property(e => e.Orapart)
                .HasColumnType("datetime")
                .HasColumnName("ORAPART");
            entity.Property(e => e.Tipoaereo)
                .HasMaxLength(6)
                .HasColumnName("TIPOAEREO");

            entity.HasOne(d => d.CittaarrNavigation).WithMany(p => p.VoloCittaarrNavigations)
                .HasForeignKey(d => d.Cittaarr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VOLO_CITTAARR_FK");

            entity.HasOne(d => d.CittapartNavigation).WithMany(p => p.VoloCittapartNavigations)
                .HasForeignKey(d => d.Cittapart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VOLO_CITTAPAR_FK");

            entity.HasOne(d => d.TipoaereoNavigation).WithMany(p => p.Volos)
                .HasForeignKey(d => d.Tipoaereo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VOLO_FK_3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
