namespace Pos.Core.Dto.Contabilidad;

public partial class ComprobanteSecuenciaDto
{
    public int Id { get; set; }
    public int ComprobanteId { get; set; }
    public int Desde { get; set; }
    public int Hasta { get; set; }
    public int Ultimo { get; set; }
    public string? FechaVence { get; set; }
    public int EmpresaId { get; set; }
}
