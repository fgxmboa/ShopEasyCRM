using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShopEasyCRM.Models;

public partial class ShopEasyContext : DbContext
{
    public ShopEasyContext()
    {
    }

    public ShopEasyContext(DbContextOptions<ShopEasyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CanalesComunicacion> CanalesComunicacions { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClienteEtiquetum> ClienteEtiqueta { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Etiqueta> Etiquetas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<HistorialPedido> HistorialPedidos { get; set; }

    public virtual DbSet<Interaccione> Interacciones { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<LogsFacturacion> LogsFacturacions { get; set; }

    public virtual DbSet<MetodosPago> MetodosPagos { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<ReportesActividad> ReportesActividads { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ShopEasyDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CanalesComunicacion>(entity =>
        {
            entity.HasKey(e => e.IdCanal).HasName("PK__canales___D4C01CC8DFFF1B1B");

            entity.ToTable("canales_comunicacion");

            entity.Property(e => e.IdCanal)
                .ValueGeneratedNever()
                .HasColumnName("id_canal");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__clientes__677F38F53D07E393");

            entity.ToTable("clientes");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("id_cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasColumnType("text")
                .HasColumnName("direccion");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.ProvinciaId).HasColumnName("provincia_id");
            entity.Property(e => e.Telefono)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.ProvinciaId)
                .HasConstraintName("FK__clientes__provin__3F466844");
        });

        modelBuilder.Entity<ClienteEtiquetum>(entity =>
        {
            entity.HasKey(e => e.IdRelacion).HasName("PK__cliente___51F3AF4C9FB42473");

            entity.ToTable("cliente_etiqueta");

            entity.Property(e => e.IdRelacion)
                .ValueGeneratedNever()
                .HasColumnName("id_relacion");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.EtiquetaId).HasColumnName("etiqueta_id");
            entity.Property(e => e.FechaAsignacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_asignacion");

            entity.HasOne(d => d.Cliente).WithMany(p => p.ClienteEtiqueta)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__cliente_e__clien__6A30C649");

            entity.HasOne(d => d.Etiqueta).WithMany(p => p.ClienteEtiqueta)
                .HasForeignKey(d => d.EtiquetaId)
                .HasConstraintName("FK__cliente_e__etiqu__6B24EA82");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__detalle___4F1332DE5B022126");

            entity.ToTable("detalle_pedido");

            entity.Property(e => e.IdDetalle)
                .ValueGeneratedNever()
                .HasColumnName("id_detalle");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("subtotal");

            entity.HasOne(d => d.Pedido).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK__detalle_p__pedid__4AB81AF0");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__detalle_p__produ__4BAC3F29");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__empleado__88B5139420AEF0BD");

            entity.ToTable("empleados");

            entity.Property(e => e.IdEmpleado)
                .ValueGeneratedNever()
                .HasColumnName("id_empleado");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.Telefono)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.Rol).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__empleados__rol_i__4222D4EF");
        });

        modelBuilder.Entity<Etiqueta>(entity =>
        {
            entity.HasKey(e => e.IdEtiqueta).HasName("PK__etiqueta__FA0DD2ADFDED3A13");

            entity.ToTable("etiquetas");

            entity.Property(e => e.IdEtiqueta)
                .ValueGeneratedNever()
                .HasColumnName("id_etiqueta");
            entity.Property(e => e.Criterio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("criterio");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__facturas__6C08ED53CB2CBD4D");

            entity.ToTable("facturas");

            entity.Property(e => e.IdFactura)
                .ValueGeneratedNever()
                .HasColumnName("id_factura");
            entity.Property(e => e.ClaveHacienda)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave_hacienda");
            entity.Property(e => e.EstadoEnvio)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado_envio");
            entity.Property(e => e.FechaEmision)
                .HasColumnType("datetime")
                .HasColumnName("fecha_emision");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_factura");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK__facturas__pedido__5535A963");
        });

        modelBuilder.Entity<HistorialPedido>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__historia__76E6C5020EFD56C5");

            entity.ToTable("historial_pedidos");

            entity.Property(e => e.IdHistorial)
                .ValueGeneratedNever()
                .HasColumnName("id_historial");
            entity.Property(e => e.ActualizadoPor).HasColumnName("actualizado_por");
            entity.Property(e => e.EstadoAnterior)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado_anterior");
            entity.Property(e => e.EstadoNuevo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado_nuevo");
            entity.Property(e => e.FechaCambio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_cambio");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");

            entity.HasOne(d => d.ActualizadoPorNavigation).WithMany(p => p.HistorialPedidos)
                .HasForeignKey(d => d.ActualizadoPor)
                .HasConstraintName("FK__historial__actua__4F7CD00D");

            entity.HasOne(d => d.Pedido).WithMany(p => p.HistorialPedidos)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK__historial__pedid__4E88ABD4");
        });

        modelBuilder.Entity<Interaccione>(entity =>
        {
            entity.HasKey(e => e.IdInteraccion).HasName("PK__interacc__0152426C65FD23D6");

            entity.ToTable("interacciones");

            entity.Property(e => e.IdInteraccion)
                .ValueGeneratedNever()
                .HasColumnName("id_interaccion");
            entity.Property(e => e.Asunto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("asunto");
            entity.Property(e => e.CanalId).HasColumnName("canal_id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");

            entity.HasOne(d => d.Canal).WithMany(p => p.Interacciones)
                .HasForeignKey(d => d.CanalId)
                .HasConstraintName("FK__interacci__canal__619B8048");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Interacciones)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__interacci__clien__60A75C0F");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Interacciones)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__interacci__emple__628FA481");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdInventario).HasName("PK__inventar__013AEB5111D8EC34");

            entity.ToTable("inventario");

            entity.Property(e => e.IdInventario)
                .ValueGeneratedNever()
                .HasColumnName("id_inventario");
            entity.Property(e => e.CantidadActual).HasColumnName("cantidad_actual");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.PuntoReorden).HasColumnName("punto_reorden");
            entity.Property(e => e.Ubicacion)
                .HasColumnType("text")
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.Producto).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__inventari__produ__52593CB8");
        });

        modelBuilder.Entity<LogsFacturacion>(entity =>
        {
            entity.HasKey(e => e.IdLog).HasName("PK__logs_fac__6CC851FE1366CF09");

            entity.ToTable("logs_facturacion");

            entity.Property(e => e.IdLog)
                .ValueGeneratedNever()
                .HasColumnName("id_log");
            entity.Property(e => e.Detalle)
                .HasColumnType("text")
                .HasColumnName("detalle");
            entity.Property(e => e.FacturaId).HasColumnName("factura_id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.GeneradoPor).HasColumnName("generado_por");

            entity.HasOne(d => d.Factura).WithMany(p => p.LogsFacturacions)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("FK__logs_fact__factu__5812160E");

            entity.HasOne(d => d.GeneradoPorNavigation).WithMany(p => p.LogsFacturacions)
                .HasForeignKey(d => d.GeneradoPor)
                .HasConstraintName("FK__logs_fact__gener__59063A47");
        });

        modelBuilder.Entity<MetodosPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodo).HasName("PK__metodos___1BBFF0F4B2C479C4");

            entity.ToTable("metodos_pago");

            entity.Property(e => e.IdMetodo)
                .ValueGeneratedNever()
                .HasColumnName("id_metodo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Notificacione>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK__notifica__8270F9A550AFFF35");

            entity.ToTable("notificaciones");

            entity.Property(e => e.IdNotificacion)
                .ValueGeneratedNever()
                .HasColumnName("id_notificacion");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.FechaEnvio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_envio");
            entity.Property(e => e.Leido).HasColumnName("leido");
            entity.Property(e => e.Mensaje)
                .HasColumnType("text")
                .HasColumnName("mensaje");
            entity.Property(e => e.Tipo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__notificac__clien__6E01572D");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__pedidos__6FF0148966BC6ED8");

            entity.ToTable("pedidos");

            entity.Property(e => e.IdPedido)
                .ValueGeneratedNever()
                .HasColumnName("id_pedido");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaPedido)
                .HasColumnType("datetime")
                .HasColumnName("fecha_pedido");
            entity.Property(e => e.MetodoPagoId).HasColumnName("metodo_pago_id");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__pedidos__cliente__46E78A0C");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.MetodoPagoId)
                .HasConstraintName("FK__pedidos__metodo___47DBAE45");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__FF341C0D7467E27E");

            entity.ToTable("productos");

            entity.Property(e => e.IdProducto)
                .ValueGeneratedNever()
                .HasColumnName("id_producto");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.IdProvincia).HasName("PK__provinci__66C18BFD8CE486DF");

            entity.ToTable("provincias");

            entity.Property(e => e.IdProvincia)
                .ValueGeneratedNever()
                .HasColumnName("id_provincia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<ReportesActividad>(entity =>
        {
            entity.HasKey(e => e.IdReporte).HasName("PK__reportes__87E4F5CBB436F650");

            entity.ToTable("reportes_actividad");

            entity.Property(e => e.IdReporte)
                .ValueGeneratedNever()
                .HasColumnName("id_reporte");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaGeneracion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_generacion");
            entity.Property(e => e.GeneradoPor).HasColumnName("generado_por");
            entity.Property(e => e.TipoReporte)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_reporte");
            entity.Property(e => e.Ubicacion)
                .HasColumnType("text")
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.GeneradoPorNavigation).WithMany(p => p.ReportesActividads)
                .HasForeignKey(d => d.GeneradoPor)
                .HasConstraintName("FK__reportes___gener__656C112C");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__roles__6ABCB5E045243EC5");

            entity.ToTable("roles");

            entity.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("PK__tickets__48C6F52388C15EEC");

            entity.ToTable("tickets");

            entity.Property(e => e.IdTicket)
                .ValueGeneratedNever()
                .HasColumnName("id_ticket");
            entity.Property(e => e.CanalId).HasColumnName("canal_id");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCierre)
                .HasColumnType("datetime")
                .HasColumnName("fecha_cierre");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Prioridad)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("prioridad");

            entity.HasOne(d => d.Canal).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CanalId)
                .HasConstraintName("FK__tickets__canal_i__5DCAEF64");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__tickets__cliente__5BE2A6F2");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__tickets__emplead__5CD6CB2B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
