using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Empresas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Contabilidad;

public partial class CuentaBanco
{
    [Key]
    public int Id { get; set; }

    public int BancoId { get; set; }

    public int EmpresaId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NumeroCuenta { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? FechaApertura { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal Monto { get; set; }

    public bool Activa { get; set; }

    [ForeignKey("BancoId")]
    [InverseProperty("CuentaBanco")]
    public virtual Banco Banco { get; set; } = null!;

    [ForeignKey("EmpresaId")]
    [InverseProperty("CuentaBanco")]
    public virtual Empresa Empresa { get; set; } = null!;
}
