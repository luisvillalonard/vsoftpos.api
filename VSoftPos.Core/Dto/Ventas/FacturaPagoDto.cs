using Pos.Core.Dto.Configuraciones;

namespace Pos.Core.Dto.Ventas;

public partial class FacturaPagoDto
{
    public long Id { get; set; }
    public long FacturaId { get; set; }
    public FormaPagoDto? FormaPago { get; set; }
    public decimal Monto { get; set; }
    public string Fecha { get; set; } = null!;
    public string? Numero { get; set; }
}
