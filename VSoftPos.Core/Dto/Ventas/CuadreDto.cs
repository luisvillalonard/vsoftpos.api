namespace Pos.Core.Dto.Ventas;

public partial class CuadreDto
{
    public long Id { get; set; }
    public string Fecha { get; set; } = null!;
    public decimal MontoInicio { get; set; }
    public int CantidadCerradas { get; set; }
    public int CantidadAbiertas { get; set; }
    public int CantidadAnuladas { get; set; }
    public decimal MontoFacturas { get; set; }
    public decimal MontoCuadre { get; set; }
    public decimal MontoFaltante { get; set; }
    public decimal MontoSobrante { get; set; }
    public decimal MontoGastos { get; set; }
    public bool Abierta { get; set; }
    public string? Comentario { get; set; }
}
