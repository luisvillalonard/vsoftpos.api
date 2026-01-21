using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Seguridad;

namespace Pos.Core.Entidades.Ventas;

public partial class Devolucion
{
    [Key]
    public long Id { get; set; }

    public long FacturaId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [StringLength(500)]
    public string? Nota { get; set; }

    public bool Anulada { get; set; }

    public long LogId { get; set; }

    [InverseProperty("Devolucion")]
    public virtual ICollection<DevolucionDetalle> DevolucionDetalle { get; set; } = new List<DevolucionDetalle>();

    [ForeignKey("FacturaId")]
    [InverseProperty("Devolucion")]
    public virtual Factura Factura { get; set; } = null!;
}
