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

    public virtual DbSet<ClienteEtiquetum> ClienteEtiqueta { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Etiqueta> Etiquetas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<HistorialPedido> HistorialPedidos { get; set; }

    public virtual DbSet<Interaccione> Interacciones { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<LogsFacturacion> LogsFacturacions { get; set; }

    public virtual DbSet<MetodosPago> MetodosPagos { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

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
            entity.HasKey(e => e.IdCanal).HasName("PK__canales___D4C01CC8E7AB2C80");

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

        modelBuilder.Entity<ClienteEtiquetum>(entity =>
        {
            entity.HasKey(e => e.IdClienteEtiqueta).HasName("PK__cliente___8CAC4C6B93FA544C");

            entity.ToTable("cliente_etiqueta");

            entity.Property(e => e.IdClienteEtiqueta)
                .ValueGeneratedNever()
                .HasColumnName("id_cliente_etiqueta");
            entity.Property(e => e.ClienteId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cliente_id");
            entity.Property(e => e.EtiquetaId).HasColumnName("etiqueta_id");
            entity.Property(e => e.FechaAsignacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_asignacion");

            entity.HasOne(d => d.Cliente).WithMany(p => p.ClienteEtiqueta)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__cliente_e__clien__68487DD7");

            entity.HasOne(d => d.Etiqueta).WithMany(p => p.ClienteEtiqueta)
                .HasForeignKey(d => d.EtiquetaId)
                .HasConstraintName("FK__cliente_e__etiqu__693CA210");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__detalle___4F1332DEB06C0A56");

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
                .HasConstraintName("FK__detalle_p__pedid__4BAC3F29");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__detalle_p__produ__4CA06362");
        });

        modelBuilder.Entity<Etiqueta>(entity =>
        {
            entity.HasKey(e => e.IdEtiqueta).HasName("PK__etiqueta__FA0DD2AD3065323F");

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
            entity.HasKey(e => e.IdFactura).HasName("PK__facturas__6C08ED530FEA762E");

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
                .HasConstraintName("FK__facturas__pedido__534D60F1");
        });

        modelBuilder.Entity<HistorialPedido>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__historia__76E6C502CCA7F4C3");

            entity.ToTable("historial_pedidos");

            entity.Property(e => e.IdHistorial)
                .ValueGeneratedNever()
                .HasColumnName("id_historial");
            entity.Property(e => e.ActualizadoPor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("actualizado_por");
            entity.Property(e => e.EstadoAnterior)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado_anterior");
            entity.Property(e => e.EstadoNuevo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado_nuevo");
            entity.Property(e => e.FechaCambio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_cambio");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");

            entity.HasOne(d => d.ActualizadoPorNavigation).WithMany(p => p.HistorialPedidos)
                .HasForeignKey(d => d.ActualizadoPor)
                .HasConstraintName("FK__historial__actua__5070F446");

            entity.HasOne(d => d.Pedido).WithMany(p => p.HistorialPedidos)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK__historial__pedid__4F7CD00D");
        });

        modelBuilder.Entity<Interaccione>(entity =>
        {
            entity.HasKey(e => e.IdInteraccion).HasName("PK__interacc__0152426C45394A88");

            entity.ToTable("interacciones");

            entity.Property(e => e.IdInteraccion)
                .ValueGeneratedNever()
                .HasColumnName("id_interaccion");
            entity.Property(e => e.Asunto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("asunto");
            entity.Property(e => e.CanalId).HasColumnName("canal_id");
            entity.Property(e => e.ClienteId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cliente_id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.EmpleadoId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empleado_id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");

            entity.HasOne(d => d.Canal).WithMany(p => p.Interacciones)
                .HasForeignKey(d => d.CanalId)
                .HasConstraintName("FK__interacci__canal__5FB337D6");

            entity.HasOne(d => d.Cliente).WithMany(p => p.InteraccioneClientes)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__interacci__clien__5EBF139D");

            entity.HasOne(d => d.Empleado).WithMany(p => p.InteraccioneEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__interacci__emple__60A75C0F");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdInventario).HasName("PK__inventar__013AEB51827C3A2A");

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
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.Producto).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__inventari__produ__44FF419A");
        });

        modelBuilder.Entity<LogsFacturacion>(entity =>
        {
            entity.HasKey(e => e.IdLog).HasName("PK__logs_fac__6CC851FE4A31C9A4");

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
            entity.Property(e => e.GeneradoPor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("generado_por");

            entity.HasOne(d => d.Factura).WithMany(p => p.LogsFacturacions)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("FK__logs_fact__factu__5629CD9C");

            entity.HasOne(d => d.GeneradoPorNavigation).WithMany(p => p.LogsFacturacions)
                .HasForeignKey(d => d.GeneradoPor)
                .HasConstraintName("FK__logs_fact__gener__571DF1D5");
        });

        modelBuilder.Entity<MetodosPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodo).HasName("PK__metodos___1BBFF0F458BDE00C");

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
            entity.HasKey(e => e.IdNotificacion).HasName("PK__notifica__8270F9A5ED7F1DEA");

            entity.ToTable("notificaciones");

            entity.Property(e => e.IdNotificacion)
                .ValueGeneratedNever()
                .HasColumnName("id_notificacion");
            entity.Property(e => e.ClienteId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cliente_id");
            entity.Property(e => e.FechaEnvio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_envio");
            entity.Property(e => e.Leido).HasColumnName("leido");
            entity.Property(e => e.Mensaje)
                .HasColumnType("text")
                .HasColumnName("mensaje");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__notificac__clien__6C190EBB");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__pedidos__6FF01489AD7E12D2");

            entity.ToTable("pedidos");

            entity.Property(e => e.IdPedido)
                .ValueGeneratedNever()
                .HasColumnName("id_pedido");
            entity.Property(e => e.ClienteId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cliente_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
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
                .HasConstraintName("FK__pedidos__cliente__47DBAE45");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.MetodoPagoId)
                .HasConstraintName("FK__pedidos__metodo___48CFD27E");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.NumeroCedula).HasName("PK__personas__AF0FC8F4604D324D");

            entity.ToTable("personas");

            entity.Property(e => e.NumeroCedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numero_cedula");
            entity.Property(e => e.Apellido1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido1");
            entity.Property(e => e.Apellido2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido2");
            entity.Property(e => e.Direccion)
                .HasColumnType("text")
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.ProvinciaId).HasColumnName("provincia_id");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Personas)
                .HasForeignKey(d => d.ProvinciaId)
                .HasConstraintName("FK__personas__provin__3F466844");

            entity.HasOne(d => d.Rol).WithMany(p => p.Personas)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__personas__rol_id__403A8C7D");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__FF341C0DD0ABEE66");

            entity.ToTable("productos");

            entity.Property(e => e.IdProducto)
                .ValueGeneratedNever()
                .HasColumnName("id_producto");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.CodigoBarras)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigo_barras");
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
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.IdProvincia).HasName("PK__provinci__66C18BFD214D3AD5");

            entity.ToTable("provincias");

            entity.Property(e => e.IdProvincia)
                .ValueGeneratedNever()
                .HasColumnName("id_provincia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<ReportesActividad>(entity =>
        {
            entity.HasKey(e => e.IdReporte).HasName("PK__reportes__87E4F5CBB4755D71");

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
            entity.Property(e => e.GeneradoPor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("generado_por");
            entity.Property(e => e.TipoReporte)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_reporte");

            entity.HasOne(d => d.GeneradoPorNavigation).WithMany(p => p.ReportesActividads)
                .HasForeignKey(d => d.GeneradoPor)
                .HasConstraintName("FK__reportes___gener__6383C8BA");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__roles__6ABCB5E02F78347D");

            entity.ToTable("roles");

            entity.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("PK__tickets__48C6F523832A0562");

            entity.ToTable("tickets");

            entity.Property(e => e.IdTicket)
                .ValueGeneratedNever()
                .HasColumnName("id_ticket");
            entity.Property(e => e.CanalId).HasColumnName("canal_id");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.ClienteId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cliente_id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.EmpleadoId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empleado_id");
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
                .HasConstraintName("FK__tickets__canal_i__5BE2A6F2");

            entity.HasOne(d => d.Cliente).WithMany(p => p.TicketClientes)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__tickets__cliente__59FA5E80");

            entity.HasOne(d => d.Empleado).WithMany(p => p.TicketEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__tickets__emplead__5AEE82B9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
