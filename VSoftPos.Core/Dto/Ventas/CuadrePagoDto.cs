using Pos.Core.Dto.Configuraciones;

namespace Pos.Core.Dto.Ventas;

public partial class CuadrePagoDto
{
    public long Id { get; set; }
    public CuadreDto Cuadre { get; set; } = null!;
    public FormaPagoDto FormaPago { get; set; } = null!;
    public decimal Monto { get; set; }
    public string? Referencia { get; set; }
    public string Fecha { get; set; } = null!;
}
