using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dadadanet.Models;

public partial class GavmeawContext : DbContext
{
    public GavmeawContext()
    {
    }

    public GavmeawContext(DbContextOptions<GavmeawContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bilder> Bilders { get; set; }

    public virtual DbSet<ConstructionMaterial> ConstructionMaterials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=192.168.2.104;User=root;Database=gavmeaw;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bilder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bilders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PatronymicName)
                .HasMaxLength(100)
                .HasColumnName("Patronymic name");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<ConstructionMaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("construction_materials");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasMaxLength(100)
                .HasColumnName("price");
            entity.Property(e => e.Quantity)
                .HasMaxLength(100)
                .HasColumnName("quantity");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
