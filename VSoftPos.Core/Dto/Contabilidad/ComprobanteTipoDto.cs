namespace Pos.Core.Dto.Contabilidad;

public partial class ComprobanteTipoDto
{
    public int Id { get; set; }
    public required string Descripcion { get; set; }
    public bool Activo { get; set; }
}
