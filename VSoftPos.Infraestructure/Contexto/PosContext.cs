using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades;
using Pos.Core.Entidades.Auxiliares;
using Pos.Core.Entidades.Compras;
using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Entidades.Empresas;
using Pos.Core.Entidades.Inventario;
using Pos.Core.Entidades.Seguridad;
using Pos.Core.Entidades.Ventas;

namespace Pos.Infraestructure.Contexto;

public partial class PosContext : DbContext
{
    public PosContext()
    {
    }

    public PosContext(DbContextOptions<PosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Almacen> Almacen { get; set; }

    public virtual DbSet<AlmacenEntrada> AlmacenEntrada { get; set; }

    public virtual DbSet<AlmacenEntradaDetalle> AlmacenEntradaDetalle { get; set; }

    public virtual DbSet<AlmacenSalida> AlmacenSalida { get; set; }

    public virtual DbSet<AlmacenSalidaDetalle> AlmacenSalidaDetalle { get; set; }

    public virtual DbSet<Anexo> Anexo { get; set; }

    public virtual DbSet<Banco> Banco { get; set; }

    public virtual DbSet<Billete> Billete { get; set; }

    public virtual DbSet<CatalogoCc> CatalogoCc { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Compra> Compra { get; set; }

    public virtual DbSet<CompraDetalle> CompraDetalle { get; set; }

    public virtual DbSet<CompraPago> CompraPago { get; set; }

    public virtual DbSet<Comprobante> Comprobante { get; set; }

    public virtual DbSet<ComprobanteSecuencia> ComprobanteSecuencia { get; set; }

    public virtual DbSet<ComprobanteTipo> ComprobanteTipo { get; set; }

    public virtual DbSet<CondicionPago> CondicionPago { get; set; }

    public virtual DbSet<Configs> Configs { get; set; }

    public virtual DbSet<Cotizacion> Cotizacion { get; set; }

    public virtual DbSet<CotizacionDetalle> CotizacionDetalle { get; set; }

    public virtual DbSet<Credito> Credito { get; set; }

    public virtual DbSet<Cuadre> Cuadre { get; set; }

    public virtual DbSet<CuadreBillete> CuadreBillete { get; set; }

    public virtual DbSet<CuadrePago> CuadrePago { get; set; }

    public virtual DbSet<CuentaBanco> CuentaBanco { get; set; }

    public virtual DbSet<Devolucion> Devolucion { get; set; }

    public virtual DbSet<DevolucionDetalle> DevolucionDetalle { get; set; }

    public virtual DbSet<Empaque> Empaque { get; set; }

    public virtual DbSet<Empleado> Empleado { get; set; }

    public virtual DbSet<Empresa> Empresa { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<FacturaDetalle> FacturaDetalle { get; set; }

    public virtual DbSet<FacturaNota> FacturaNota { get; set; }

    public virtual DbSet<FacturaPago> FacturaPago { get; set; }

    public virtual DbSet<FacturaTipo> FacturaTipo { get; set; }

    public virtual DbSet<FormaPago> FormaPago { get; set; }

    public virtual DbSet<Gasto> Gasto { get; set; }

    public virtual DbSet<GastoTipo> GastoTipo { get; set; }

    public virtual DbSet<Genero> Genero { get; set; }

    public virtual DbSet<Grupo> Grupo { get; set; }

    public virtual DbSet<Horario> Horario { get; set; }

    public virtual DbSet<Impuesto> Impuesto { get; set; }

    public virtual DbSet<Medida> Medida { get; set; }

    public virtual DbSet<Permiso> Permiso { get; set; }

    public virtual DbSet<Posicion> Posicion { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Stock> Stock { get; set; }

    public virtual DbSet<Suplidor> Suplidor { get; set; }

    public virtual DbSet<Unidad> Unidad { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<VwAlmacenes> VwAlmacenes { get; set; }

    public virtual DbSet<VwComprobantes> VwComprobantes { get; set; }

    public virtual DbSet<VwComprobantesSecuencias> VwComprobantesSecuencias { get; set; }

    public virtual DbSet<VwProductos> VwProductos { get; set; }

    public virtual DbSet<VwUnidadesMedidas> VwUnidadesMedidas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacen>(entity =>
        {
            entity.HasOne(d => d.Empresa).WithMany(p => p.Almacen).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AlmacenEntrada>(entity =>
        {
            entity.HasOne(d => d.Almacen).WithMany(p => p.AlmacenEntrada).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AlmacenEntradaDetalle>(entity =>
        {
            entity.HasOne(d => d.Entrada).WithMany(p => p.AlmacenEntradaDetalle).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Producto).WithMany(p => p.AlmacenEntradaDetalle).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AlmacenSalida>(entity =>
        {
            entity.HasOne(d => d.Almacen).WithMany(p => p.AlmacenSalida).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AlmacenSalidaDetalle>(entity =>
        {
            entity.HasOne(d => d.Producto).WithMany(p => p.AlmacenSalidaDetalle).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Salida).WithMany(p => p.AlmacenSalidaDetalle).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasOne(d => d.Empresa).WithMany(p => p.Compra).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Suplidor).WithMany(p => p.Compra).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CompraDetalle>(entity =>
        {
            entity.HasOne(d => d.Almacen).WithMany(p => p.CompraDetalle).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Compra).WithMany(p => p.CompraDetalle).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Empaque).WithMany(p => p.CompraDetalle).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Impuesto).WithMany(p => p.CompraDetalle).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Producto).WithMany(p => p.CompraDetalle).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CompraPago>(entity =>
        {
            entity.HasOne(d => d.Compra).WithMany(p => p.CompraPago).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Comprobante>(entity =>
        {
            entity.HasOne(d => d.Empresa).WithMany(p => p.Comprobante).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Tipo).WithMany(p => p.Comprobante).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ComprobanteSecuencia>(entity =>
        {
            entity.HasOne(d => d.Comprobante).WithMany(p => p.ComprobanteSecuencia).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Empresa).WithMany(p => p.ComprobanteSecuencia).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Cotizacion>(entity =>
        {
            entity.HasOne(d => d.Cliente).WithMany(p => p.Cotizacion).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Cotizacion).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CotizacionDetalle>(entity =>
        {
            entity.HasOne(d => d.Cotizacion).WithMany(p => p.CotizacionDetalle).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductoNavigation).WithMany(p => p.CotizacionDetalle).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Credito>(entity =>
        {
            entity.HasOne(d => d.Cliente).WithMany(p => p.Credito).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CuadreBillete>(entity =>
        {
            entity.HasOne(d => d.Billete).WithMany(p => p.CuadreBillete).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Cuadre).WithMany(p => p.CuadreBillete).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CuadrePago>(entity =>
        {
            entity.HasOne(d => d.Cuadre).WithMany(p => p.CuadrePago).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.FormaPago).WithMany(p => p.CuadrePago).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CuentaBanco>(entity =>
        {
            entity.HasOne(d => d.Banco).WithMany(p => p.CuentaBanco).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Empresa).WithMany(p => p.CuentaBanco).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Devolucion>(entity =>
        {
            entity.HasOne(d => d.Factura).WithMany(p => p.Devolucion).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DevolucionDetalle>(entity =>
        {
            entity.HasOne(d => d.Devolucion).WithMany(p => p.DevolucionDetalle).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductoNavigation).WithMany(p => p.DevolucionDetalle).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasOne(d => d.Empresa).WithMany(p => p.Empleado).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("Factura_Insert"));

            entity.HasOne(d => d.Cliente).WithMany(p => p.Factura).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Factura).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.FacturaTipo).WithMany(p => p.Factura).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<FacturaDetalle>(entity =>
        {
            entity.HasOne(d => d.Factura).WithMany(p => p.FacturaDetalle).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductoNavigation).WithMany(p => p.FacturaDetalle).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<FacturaNota>(entity =>
        {
            entity.HasOne(d => d.Factura).WithMany(p => p.FacturaNota).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<FacturaPago>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("FacturaPago_Insert"));

            entity.HasOne(d => d.Factura).WithMany(p => p.FacturaPago).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.FormaPago).WithMany(p => p.FacturaPago).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.HasOne(d => d.Empresa).WithMany(p => p.Gasto).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Tipo).WithMany(p => p.Gasto).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tanda");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Horario).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Medida>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Medidas");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasOne(d => d.Rol).WithMany(p => p.Permiso).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Posicion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Cargo");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Posicion).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Inventario");

            entity.HasOne(d => d.Impuesto).WithMany(p => p.Producto).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasOne(d => d.Almacen).WithMany(p => p.Stock).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Producto).WithMany(p => p.Stock).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Unidad>(entity =>
        {
            entity.HasOne(d => d.Medida).WithMany(p => p.Unidad).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasOne(d => d.Empresa).WithMany(p => p.Usuario).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuario).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<VwAlmacenes>(entity =>
        {
            entity.ToView("VwAlmacenes");
        });

        modelBuilder.Entity<VwComprobantes>(entity =>
        {
            entity.ToView("VwComprobantes");
        });

        modelBuilder.Entity<VwComprobantesSecuencias>(entity =>
        {
            entity.ToView("VwComprobantesSecuencias");
        });

        modelBuilder.Entity<VwProductos>(entity =>
        {
            entity.ToView("VwProductos");
        });

        modelBuilder.Entity<VwUnidadesMedidas>(entity =>
        {
            entity.ToView("VwUnidadesMedidas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
