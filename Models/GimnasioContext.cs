using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Gimnasio.Models;

public partial class GimnasioContext : DbContext
{
    public GimnasioContext()
    {
    }

    public GimnasioContext(DbContextOptions<GimnasioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clase> Clases { get; set; }

    public virtual DbSet<Membresium> Membresia { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Reservaclase> Reservaclases { get; set; }

    public virtual DbSet<Trabajador> Trabajadors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.ClaseId).HasName("PRIMARY");

            entity.ToTable("clase");

            entity.HasIndex(e => e.ClaseInstructorId, "ClaseInstructorID");

            entity.Property(e => e.ClaseId)
                .HasColumnType("int(11)")
                .HasColumnName("ClaseID");
            entity.Property(e => e.ClaseCapacidadMaxima)
                .HasDefaultValueSql("'50'")
                .HasColumnType("int(11)");
            entity.Property(e => e.ClaseDescripcion).HasColumnType("text");
            entity.Property(e => e.ClaseDiaSemana)
                .HasDefaultValueSql("'LUNES'")
                .HasColumnType("enum('LUNES','MARTES','MIERCOLES','JUEVES','VIERNES','SABADO','DOMINGO')");
            entity.Property(e => e.ClaseDuracion).HasColumnType("time");
            entity.Property(e => e.ClaseEstado)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.ClaseHoraInicio).HasColumnType("datetime");
            entity.Property(e => e.ClaseInstructorId)
                .HasColumnType("int(11)")
                .HasColumnName("ClaseInstructorID");
            entity.Property(e => e.ClaseNombre)
                .HasMaxLength(155)
                .HasDefaultValueSql("''");

            entity.HasOne(d => d.ClaseInstructor).WithMany(p => p.Clases)
                .HasForeignKey(d => d.ClaseInstructorId)
                .HasConstraintName("clase_ibfk_1");
        });

        modelBuilder.Entity<Membresium>(entity =>
        {
            entity.HasKey(e => e.MembresiaId).HasName("PRIMARY");

            entity.ToTable("membresia");

            entity.Property(e => e.MembresiaId)
                .HasColumnType("int(11)")
                .HasColumnName("MembresiaID");
            entity.Property(e => e.MembresiaAccesoClases)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.MembresiaAccesoInstalaciones)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.MembresiaDescripcionBeneficios).HasColumnType("text");
            entity.Property(e => e.MembresiaEstado)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.MembresiaPrecio).HasPrecision(10, 2);
            entity.Property(e => e.MembresiaTipo)
                .HasDefaultValueSql("'MENSUAL'")
                .HasColumnType("enum('MENSUAL','TRIMESTRAL','ANUAL')");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.PagoId).HasName("PRIMARY");

            entity.ToTable("pago");

            entity.HasIndex(e => e.PagoMembresiaId, "PagoMembresiaID");

            entity.HasIndex(e => e.PagoUsuarioId, "PagoUsuarioID");

            entity.Property(e => e.PagoId)
                .HasColumnType("int(11)")
                .HasColumnName("PagoID");
            entity.Property(e => e.PagoEstado)
                .HasDefaultValueSql("'COMPLETADO'")
                .HasColumnType("enum('COMPLETADO','PENDIENTE')");
            entity.Property(e => e.PagoFecha)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.PagoMembresiaId)
                .HasColumnType("int(11)")
                .HasColumnName("PagoMembresiaID");
            entity.Property(e => e.PagoMetodo)
                .HasDefaultValueSql("'EFECTIVO'")
                .HasColumnType("enum('TARJETA','DEBITO','EFECTIVO','TRANSFERENCIA')");
            entity.Property(e => e.PagoMonto)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'19.99'");
            entity.Property(e => e.PagoUsuarioId)
                .HasColumnType("int(11)")
                .HasColumnName("PagoUsuarioID");

            entity.HasOne(d => d.PagoMembresia).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.PagoMembresiaId)
                .HasConstraintName("pago_ibfk_2");

            entity.HasOne(d => d.PagoUsuario).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.PagoUsuarioId)
                .HasConstraintName("pago_ibfk_1");
        });

        modelBuilder.Entity<Reservaclase>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PRIMARY");

            entity.ToTable("reservaclase");

            entity.HasIndex(e => e.ReservaClaseId, "ReservaClaseID");

            entity.HasIndex(e => e.ReservaUsuarioId, "ReservaUsuarioID");

            entity.Property(e => e.ReservaId)
                .HasColumnType("int(11)")
                .HasColumnName("ReservaID");
            entity.Property(e => e.ReservaClaseId)
                .HasColumnType("int(11)")
                .HasColumnName("ReservaClaseID");
            entity.Property(e => e.ReservaEstado)
                .HasDefaultValueSql("'CONFIRMADA'")
                .HasColumnType("enum('CONFIRMADA','CANCELADA')");
            entity.Property(e => e.ReservaFecha)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.ReservaUsuarioId)
                .HasColumnType("int(11)")
                .HasColumnName("ReservaUsuarioID");

            entity.HasOne(d => d.ReservaClase).WithMany(p => p.Reservaclases)
                .HasForeignKey(d => d.ReservaClaseId)
                .HasConstraintName("reservaclase_ibfk_2");

            entity.HasOne(d => d.ReservaUsuario).WithMany(p => p.Reservaclases)
                .HasForeignKey(d => d.ReservaUsuarioId)
                .HasConstraintName("reservaclase_ibfk_1");
        });

        modelBuilder.Entity<Trabajador>(entity =>
        {
            entity.HasKey(e => e.TrabajadorId).HasName("PRIMARY");

            entity.ToTable("trabajador");

            entity.HasIndex(e => e.TrabajadorDocIdent, "TrabajadorDocIdent").IsUnique();

            entity.HasIndex(e => e.TrabajadorEmail, "TrabajadorEmail").IsUnique();

            entity.HasIndex(e => e.TrabajadorTelefono, "TrabajadorTelefono").IsUnique();

            entity.Property(e => e.TrabajadorId)
                .HasColumnType("int(11)")
                .HasColumnName("TrabajadorID");
            entity.Property(e => e.TrabajadorApellidos)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TrabajadorCargo)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TrabajadorDireccion)
                .HasMaxLength(155)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TrabajadorDocIdent)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TrabajadorEmail)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TrabajadorEstado)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.TrabajadorFechaAlta)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.TrabajadorNombre)
                .HasMaxLength(155)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TrabajadorSalario)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'1080.98'");
            entity.Property(e => e.TrabajadorTelefono)
                .HasMaxLength(15)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.UsuarioDocIdent, "UsuarioDocIdent").IsUnique();

            entity.HasIndex(e => e.UsuarioEmail, "UsuarioEmail").IsUnique();

            entity.HasIndex(e => e.UsuarioTelefono, "UsuarioTelefono").IsUnique();

            entity.Property(e => e.UsuarioId)
                .HasColumnType("int(11)")
                .HasColumnName("UsuarioID");
            entity.Property(e => e.UsuarioApellidos).HasMaxLength(255);
            entity.Property(e => e.UsuarioDireccion).HasMaxLength(155);
            entity.Property(e => e.UsuarioDocIdent)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UsuarioEmail).HasMaxLength(50);
            entity.Property(e => e.UsuarioEstado)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.UsuarioFechaAlta)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioNombre).HasMaxLength(155);
            entity.Property(e => e.UsuarioTelefono).HasMaxLength(15);
            entity.Property(e => e.UsuarioTipoMembresia)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
