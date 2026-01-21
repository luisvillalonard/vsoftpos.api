using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Pos.Core.Entidades.Contabilidad;

[Keyless]
public partial class VwComprobantesSecuencias
{
    public int Id { get; set; }

    public int ComprobanteId { get; set; }

    [StringLength(100)]
    public string Comprobante { get; set; } = null!;

    public int Desde { get; set; }

    public int Hasta { get; set; }

    public int Ultimo { get; set; }

    public DateOnly? FechaVence { get; set; }

    public int EmpresaId { get; set; }

    [StringLength(200)]
    public string? Empresa { get; set; }
}
