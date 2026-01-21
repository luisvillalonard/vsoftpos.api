using Pos.Core.Dto.Configuraciones;
using Pos.Core.Dto.Contabilidad;

namespace Pos.Core.Dto.Ventas;

public partial class ClienteDto
{
    public int Id { get; set; }
    public string FechaIngreso { get; set; } = null!;
    public bool EsEmpresa { get; set; }
    public bool Generico { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Cedula { get; set; }
    public string? Rnc { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public CondicionPagoDto? CondicionPago { get; set; }
    public ComprobanteDto? Comprobante { get; set; }
    public CreditoDto? Credito { get; set; }
    public bool Activo { get; set; }
}
