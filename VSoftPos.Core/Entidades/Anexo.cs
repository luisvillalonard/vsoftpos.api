using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Inventario;
using Pos.Core.Entidades.Empresas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades;

public partial class Anexo
{
    [Key]
    public long Id { get; set; }

    public byte[] Imagen { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string Extension { get; set; } = null!;

    [InverseProperty("Logo")]
    public virtual ICollection<Empresa> Empresa { get; set; } = new List<Empresa>();

    [InverseProperty("Foto")]
    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
