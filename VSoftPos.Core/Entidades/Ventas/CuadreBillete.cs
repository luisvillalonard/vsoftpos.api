using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Auxiliares;

namespace Pos.Core.Entidades.Ventas;

public partial class CuadreBillete
{
    [Key]
    public long Id { get; set; }

    public long CuadreId { get; set; }

    public int BilleteId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Denominacion { get; set; } = null!;

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Valor { get; set; }

    public int Cantidad { get; set; }

    [ForeignKey("BilleteId")]
    [InverseProperty("CuadreBillete")]
    public virtual Billete Billete { get; set; } = null!;

    [ForeignKey("CuadreId")]
    [InverseProperty("CuadreBillete")]
    public virtual Cuadre Cuadre { get; set; } = null!;
}
