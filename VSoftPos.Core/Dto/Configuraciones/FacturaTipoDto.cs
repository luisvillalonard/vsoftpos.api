namespace Pos.Core.Dto.Configuraciones;

public partial class FacturaTipoDto
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public bool Primaria { get; set; }
    public bool RequiereMonto { get; set; }
}
