using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Empresas;

namespace Pos.Core.Entidades.Auxiliares;

public partial class Genero
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("Genero")]
    public virtual ICollection<Empleado> Empleado { get; set; } = new List<Empleado>();
}
