using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaVentas.MODEL;

public partial class DbventasContext : DbContext
{
    public DbventasContext()
    {
    }

    public DbventasContext(DbContextOptions<DbventasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<DetalleVenta> Detalleventa { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Menurol> Menurols { get; set; }

    public virtual DbSet<Numerodocumento> Numerodocumentos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=dbventas;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.ToTable("categoria");

            entity.Property(e => e.IdCategoria)
                .HasColumnType("int(11)")
                .HasColumnName("idCategoria");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PRIMARY");

            entity.ToTable("detalleventa");

            entity.HasIndex(e => e.IdProducto, "idProducto");

            entity.HasIndex(e => e.IdVenta, "idVenta");

            entity.Property(e => e.IdDetalleVenta)
                .HasColumnType("int(11)")
                .HasColumnName("idDetalleVenta");
            entity.Property(e => e.Cantidad)
                .HasColumnType("int(11)")
                .HasColumnName("cantidad");
            entity.Property(e => e.IdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("idProducto");
            entity.Property(e => e.IdVenta)
                .HasColumnType("int(11)")
                .HasColumnName("idVenta");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("detalleventa_ibfk_2");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("detalleventa_ibfk_1");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PRIMARY");

            entity.ToTable("menu");

            entity.Property(e => e.IdMenu)
                .HasColumnType("int(11)")
                .HasColumnName("idMenu");
            entity.Property(e => e.Icono)
                .HasMaxLength(50)
                .HasColumnName("icono");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Menurol>(entity =>
        {
            entity.HasKey(e => e.IdMenuRol).HasName("PRIMARY");

            entity.ToTable("menurol");

            entity.HasIndex(e => e.IdMenu, "idMenu");

            entity.HasIndex(e => e.IdRol, "idRol");

            entity.Property(e => e.IdMenuRol)
                .HasColumnType("int(11)")
                .HasColumnName("idMenuRol");
            entity.Property(e => e.IdMenu)
                .HasColumnType("int(11)")
                .HasColumnName("idMenu");
            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.Menurols)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("menurol_ibfk_1");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Menurols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("menurol_ibfk_2");
        });

        modelBuilder.Entity<Numerodocumento>(entity =>
        {
            entity.HasKey(e => e.IdNumeroDocumento).HasName("PRIMARY");

            entity.ToTable("numerodocumento");

            entity.Property(e => e.IdNumeroDocumento)
                .HasColumnType("int(11)")
                .HasColumnName("idNumeroDocumento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.UltimoNumero)
                .HasColumnType("int(11)")
                .HasColumnName("ultimo_Numero");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PRIMARY");

            entity.ToTable("producto");

            entity.HasIndex(e => e.IdCategoria, "idCategoria");

            entity.Property(e => e.IdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("idProducto");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdCategoria)
                .HasColumnType("int(11)")
                .HasColumnName("idCategoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Stock)
                .HasColumnType("int(11)")
                .HasColumnName("stock");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("producto_ibfk_1");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("idRol");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.IdRol, "idRol");

            entity.Property(e => e.IdUsuario)
                .HasColumnType("int(11)")
                .HasColumnName("idUsuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(40)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(40)
                .HasColumnName("correo");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("idRol");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .HasColumnName("nombreCompleto");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("usuario_ibfk_1");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PRIMARY");

            entity.ToTable("venta");

            entity.Property(e => e.IdVenta)
                .HasColumnType("int(11)")
                .HasColumnName("idVenta");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(40)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(50)
                .HasColumnName("tipoPago");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
