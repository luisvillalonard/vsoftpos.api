using Pos.Core.Entidades.Compras;
using Pos.Core.Entidades.Empresas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Inventario;

public partial class Almacen
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [StringLength(200)]
    public string? Descripcion { get; set; }

    public int EmpresaId { get; set; }

    public bool Activo { get; set; }

    [InverseProperty("Almacen")]
    public virtual ICollection<AlmacenEntrada> AlmacenEntrada { get; set; } = new List<AlmacenEntrada>();

    [InverseProperty("Almacen")]
    public virtual ICollection<AlmacenSalida> AlmacenSalida { get; set; } = new List<AlmacenSalida>();

    [InverseProperty("Almacen")]
    public virtual ICollection<CompraDetalle> CompraDetalle { get; set; } = new List<CompraDetalle>();

    [ForeignKey("EmpresaId")]
    [InverseProperty("Almacen")]
    public virtual Empresa Empresa { get; set; } = null!;

    [InverseProperty("Almacen")]
    public virtual ICollection<Stock> Stock { get; set; } = new List<Stock>();
}
