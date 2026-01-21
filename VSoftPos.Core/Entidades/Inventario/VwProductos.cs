using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Inventario;

[Keyless]
public partial class VwProductos
{
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

    [StringLength(50)]
    public string Grupo { get; set; } = null!;

    public bool SeCompra { get; set; }

    public int? Categoria606 { get; set; }

    public bool SeVende { get; set; }

    public int? Categoria607 { get; set; }

    public int ImpuestoId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Impuesto { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Costo { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Precio { get; set; }

    public int Reorden { get; set; }

    public int Stock { get; set; }

    public bool VentaSinStock { get; set; }

    [Column("CostoCC")]
    public int? CostoCc { get; set; }

    [Column("VentaCC")]
    public int? VentaCc { get; set; }

    [Column("DescuentoCC")]
    public int? DescuentoCc { get; set; }

    public bool Activo { get; set; }

    public long? FotoId { get; set; }
}
