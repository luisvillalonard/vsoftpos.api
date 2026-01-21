using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Compras;
using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Entidades.Empresas;
using Pos.Core.Entidades.Ventas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Inventario;

public partial class Producto
{
    [Key]
    public int Id { get; set; }

    public bool EsProducto { get; set; }

    public bool Especifico { get; set; }

    public bool Detallable { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Codigo { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(300)]
    public string? Descripcion { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CodigoBarra { get; set; }

    public int? GrupoId { get; set; }

    public bool SeCompra { get; set; }

    public int? Categoria606 { get; set; }

    public bool SeVende { get; set; }

    public int? Categoria607 { get; set; }

    public int ImpuestoId { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Costo { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Precio { get; set; }

    public int Reorden { get; set; }

    public bool VentaSinStock { get; set; }

    [Column("CostoCC")]
    public int? CostoCc { get; set; }

    [Column("VentaCC")]
    public int? VentaCc { get; set; }

    [Column("DescuentoCC")]
    public int? DescuentoCc { get; set; }

    public bool Activo { get; set; }

    public long? FotoId { get; set; }

    [InverseProperty("Producto")]
    public virtual ICollection<AlmacenEntradaDetalle> AlmacenEntradaDetalle { get; set; } = new List<AlmacenEntradaDetalle>();

    [InverseProperty("Producto")]
    public virtual ICollection<AlmacenSalidaDetalle> AlmacenSalidaDetalle { get; set; } = new List<AlmacenSalidaDetalle>();

    [InverseProperty("Producto")]
    public virtual ICollection<CompraDetalle> CompraDetalle { get; set; } = new List<CompraDetalle>();

    [InverseProperty("ProductoNavigation")]
    public virtual ICollection<CotizacionDetalle> CotizacionDetalle { get; set; } = new List<CotizacionDetalle>();

    [InverseProperty("ProductoNavigation")]
    public virtual ICollection<DevolucionDetalle> DevolucionDetalle { get; set; } = new List<DevolucionDetalle>();

    [InverseProperty("ProductoNavigation")]
    public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; } = new List<FacturaDetalle>();

    [ForeignKey("FotoId")]
    [InverseProperty("Producto")]
    public virtual Anexo? Foto { get; set; }

    [ForeignKey("GrupoId")]
    [InverseProperty("ProductoNavigation")]
    public virtual Grupo? Grupo { get; set; }

    [ForeignKey("ImpuestoId")]
    [InverseProperty("Producto")]
    public virtual Impuesto Impuesto { get; set; } = null!;

    [InverseProperty("Producto")]
    public virtual ICollection<Stock> Stock { get; set; } = new List<Stock>();
}
