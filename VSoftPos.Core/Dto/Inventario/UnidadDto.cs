namespace Pos.Core.Dto.Inventario;

public partial class UnidadDto
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public int MedidaId { get; set; }
    public bool Activa { get; set; }
}
