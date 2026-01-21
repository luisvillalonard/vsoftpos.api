namespace Pos.Core.Dto.Ventas;

public partial class CotizacionDto
{
    public int Id { get; set; }
    public int EmpresaId { get; set; }
    public string Empresa { get; set; } = null!;
    public int ClienteId { get; set; }
    public string Cliente { get; set; } = null!;
    public string Fecha { get; set; } = null!;
    public decimal SubTotal { get; set; }
    public decimal Itbis { get; set; }
    public decimal Descuento { get; set; }
    public decimal Total { get; set; }
    public string? Comentario { get; set; }
    public bool Abierta { get; set; }
    public bool Anulada { get; set; }
}
