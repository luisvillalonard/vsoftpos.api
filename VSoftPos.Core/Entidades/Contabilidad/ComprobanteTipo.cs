using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pos.Core.Entidades.Contabilidad;

public partial class ComprobanteTipo
{
    [Key]
    public int Id { get; set; }

    [StringLength(75)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    [InverseProperty("Tipo")]
    public virtual ICollection<Comprobante> Comprobante { get; set; } = new List<Comprobante>();
}
