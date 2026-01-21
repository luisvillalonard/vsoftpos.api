namespace Pos.Core.Dto.Contabilidad;

public partial class CatalogoCcDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int Grupo { get; set; }
    public int? Nivel1 { get; set; }
    public int? Nivel2 { get; set; }
    public int? Nivel3 { get; set; }
    public string Codigo { get; set; } = null!;
}
