using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pos.Core.Entidades.Ventas;

public partial class FacturaNota
{
    [Key]
    public long Id { get; set; }

    public long FacturaId { get; set; }

    [StringLength(500)]
    public string Nota { get; set; } = null!;

    [ForeignKey("FacturaId")]
    [InverseProperty("FacturaNota")]
    public virtual Factura Factura { get; set; } = null!;
}
