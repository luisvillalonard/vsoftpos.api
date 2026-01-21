using Pos.Core.Dto.Empresas;

namespace Pos.Core.Dto.Contabilidad;

public partial class CuentaBancoDto
{
    public int Id { get; set; }
    public BancoDto? Banco { get; set; }
    public EmpresaDto? Empresa { get; set; }
    public required string NumeroCuenta { get; set; }
    public string? FechaApertura { get; set; }
    public decimal Monto { get; set; }
    public bool Activa { get; set; }
}
