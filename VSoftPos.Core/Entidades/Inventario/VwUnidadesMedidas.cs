using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Pos.Core.Entidades.Inventario;

[Keyless]
public partial class VwUnidadesMedidas
{
    public int Id { get; set; }

    [StringLength(50)]
    public string Descripcion { get; set; } = null!;

    public int MedidaId { get; set; }

    [StringLength(50)]
    public string Medida { get; set; } = null!;

    public bool Activa { get; set; }
}
