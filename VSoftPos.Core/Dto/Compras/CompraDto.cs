using Pos.Core.Dto.Empresas;

namespace Pos.Core.Dto.Compras;

public partial class CompraDto
{
    public int Id { get; set; }
    public string Fecha { get; set; } = null!;
    public string NumeroFactura { get; set; } = null!;
    public SuplidorDto? Suplidor { get; set; }
    public EmpresaDto? Empresa { get; set; }
    public string? FechaLimite { get; set; }
    public bool Pagada { get; set; }
    public decimal MontoFactura { get; set; }
    public decimal MontoPagado { get; set; }
    public bool Anulada { get; set; }

    public CompraDetalleDto[] Detalle { get; set; }
    public CompraPagoDto[] Pagos { get; set; }

    public CompraDto()
    {
        Detalle = Array.Empty<CompraDetalleDto>();
        Pagos = Array.Empty<CompraPagoDto>();
    }
}
