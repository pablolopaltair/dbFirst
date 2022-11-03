using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dbFirstDAL.Modelo
{
    public partial class trabajadoresdbFirstContext : DbContext
    {
        public trabajadoresdbFirstContext()
        {
        }

        public trabajadoresdbFirstContext(DbContextOptions<trabajadoresdbFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Trabajadore> Trabajadores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=trabajadoresdbFirst;User Id=postgres;Password=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trabajadore>(entity =>
            {
                entity.HasKey(e => e.Nombre)
                    .HasName("trabajadores_pkey");

                entity.ToTable("trabajadores");

                entity.Property(e => e.Nombre)
                    .HasColumnType("character varying")
                    .HasColumnName("nombre");

                entity.Property(e => e.Apellidos)
                    .HasColumnType("character varying")
                    .HasColumnName("apellidos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
