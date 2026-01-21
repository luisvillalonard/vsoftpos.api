using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Ventas;

namespace Pos.Core.Entidades.Auxiliares;

public partial class Billete
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Denominacion { get; set; } = null!;

    [Column(TypeName = "numeric(18, 0)")]
    public decimal Valor { get; set; }

    [InverseProperty("Billete")]
    public virtual ICollection<CuadreBillete> CuadreBillete { get; set; } = new List<CuadreBillete>();
}
