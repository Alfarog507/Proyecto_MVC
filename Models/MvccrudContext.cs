using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCCRUD2.Models;

public partial class MvccrudContext : DbContext
{
    public MvccrudContext()
    {
    }

    public MvccrudContext(DbContextOptions<MvccrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CamposEncuesta> CamposEncuestas { get; set; }

    public virtual DbSet<Encuesta> Encuestas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            /*optionsBuilder.UseSqlServer("Server=DESKTOP-5QKQK0L;Database=Mvccrud;Trusted_Connection=True;");*/
        }
    } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CamposEncuesta>(entity =>
        {
            entity.HasKey(e => e.CampoId).HasName("PK__Campos_E__0F77756BDA7AAE5F");

            entity.ToTable("Campos_Encuestas");

            entity.Property(e => e.CampoId).HasColumnName("campo_id");
            entity.Property(e => e.EncuestaId).HasColumnName("encuesta_id");
            entity.Property(e => e.EsRequerido).HasColumnName("es_requerido");
            entity.Property(e => e.NombreCampo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_campo");
            entity.Property(e => e.TipoCampo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tipo_campo");

            entity.HasOne(d => d.Encuesta).WithMany(p => p.CamposEncuesta)
                .HasForeignKey(d => d.EncuestaId)
                .HasConstraintName("FK__Campos_En__encue__3C69FB99");
        });

        modelBuilder.Entity<Encuesta>(entity =>
        {
            entity.HasKey(e => e.EncuestaId).HasName("PK__Encuesta__8F3A1FC908529FF2");

            entity.Property(e => e.EncuestaId).HasColumnName("encuesta_id");
            entity.Property(e => e.DescripcionEncuesta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion_encuesta");
            entity.Property(e => e.NombreEncuesta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_encuesta");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Encuesta)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Encuestas__user___398D8EEE");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Usuarios__B9BE370F58E518CA");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.Password)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
