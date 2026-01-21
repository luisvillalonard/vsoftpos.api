namespace Pos.Core.Dto.Configuraciones;

public partial class CondicionPagoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public bool AplicaCliente { get; set; }
    public bool AplicaSuplidor { get; set; }
    public bool AlContado { get; set; }
    public int DiasVencimiento { get; set; }
    public bool Activo { get; set; }
}
