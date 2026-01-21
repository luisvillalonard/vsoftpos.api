using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Entidades.Empresas;
using Pos.Core.Entidades.Inventario;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Compras;

public partial class Suplidor
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "date")]
    public DateTime FechaIngreso { get; set; }

    public bool EsEmpresa { get; set; }

    [StringLength(200)]
    public string Nombre { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string? Cedula { get; set; }

    [Column("RNC")]
    [StringLength(9)]
    [Unicode(false)]
    public string? Rnc { get; set; }

    [StringLength(200)]
    public string? Direccion { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Correo { get; set; }

    public bool Informal { get; set; }

    public int? CondicionPagoId { get; set; }

    public bool Credito { get; set; }

    public bool Activo { get; set; }

    [InverseProperty("Suplidor")]
    public virtual ICollection<Compra> Compra { get; set; } = new List<Compra>();

    [ForeignKey("CondicionPagoId")]
    [InverseProperty("Suplidor")]
    public virtual CondicionPago? CondicionPago { get; set; }
}
