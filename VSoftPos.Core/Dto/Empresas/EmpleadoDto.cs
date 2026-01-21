namespace Pos.Core.Dto.Empresas;

public partial class EmpleadoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public bool Femenino { get; set; }
    public string? Cedula { get; set; }
    public PosicionDto? Posicion { get; set; }
    public decimal? Salario { get; set; }
    public bool Activo { get; set; }
    public EmpresaDto? Empresa { get; set; }
    public HorarioDto? Horario { get; set; }
    public long? FotoId { get; set; }
    public string? FechaEntrada { get; set; }
    public string? FechaSalida { get; set; }
    public string? Correo { get; set; }
}
