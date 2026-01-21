using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pos.Core.Entidades.Contabilidad;

[Table("CatalogoCC")]
public partial class CatalogoCc
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Nombre { get; set; } = null!;

    public int Grupo { get; set; }

    public int? Nivel1 { get; set; }

    public int? Nivel2 { get; set; }

    public int? Nivel3 { get; set; }

    public string Codigo { get; set; } = null!;
}
