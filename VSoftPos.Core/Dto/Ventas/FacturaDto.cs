using Pos.Core.Dto.Configuraciones;
using Pos.Core.Dto.Contabilidad;
using Pos.Core.Dto.Empresas;

namespace Pos.Core.Dto.Ventas;

public partial class FacturaDto
{
    public long Id { get; set; }
    public int Numero { get; set; }
    public EmpresaDto? Empresa { get; set; }
    public ClienteDto? Cliente { get; set; }
    public FacturaTipoDto? FacturaTipo { get; set; }
    public string FechaEmision { get; set; } = null!;
    public string? FechaSaldo { get; set; }
    public string? FechaLimitePago { get; set; }
    public string? FechaEntrega { get; set; }
    public string? Ncf { get; set; }
    public ComprobanteDto? Comprobante { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Itbis { get; set; }
    public decimal Descuento { get; set; }
    public decimal Total { get; set; }
    public decimal Pagado { get; set; }
    public decimal Devuelto { get; set; }
    public string? Nota { get; set; }
    public bool Abierta { get; set; }
    public bool Anulada { get; set; }
    public FacturaDetalleDto[] Items { get; set; }
    public FacturaNotaDto[] Notas { get; set; }
    public FacturaPagoDto[] Pagos { get; set; }

    public FacturaDto()
    {
        Items = Array.Empty<FacturaDetalleDto>();
        Notas = Array.Empty<FacturaNotaDto>();
        Pagos = Array.Empty<FacturaPagoDto>();
    }
}
