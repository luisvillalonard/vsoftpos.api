using Pos.Core.Entidades.Empresas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Contabilidad;

public partial class ComprobanteSecuencia
{
    [Key]
    public int Id { get; set; }

    public int ComprobanteId { get; set; }

    public int Desde { get; set; }

    public int Hasta { get; set; }

    public int Ultimo { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaVence { get; set; }

    public int EmpresaId { get; set; }

    [ForeignKey("ComprobanteId")]
    [InverseProperty("ComprobanteSecuencia")]
    public virtual Comprobante Comprobante { get; set; } = null!;

    [ForeignKey("EmpresaId")]
    [InverseProperty("ComprobanteSecuencia")]
    public virtual Empresa Empresa { get; set; } = null!;
}
