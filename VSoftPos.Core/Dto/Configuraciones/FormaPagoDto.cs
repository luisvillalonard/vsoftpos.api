namespace Pos.Core.Dto.Configuraciones;

public partial class FormaPagoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public bool Primaria { get; set; }
    public bool AplicaEnFactura { get; set; }
    public bool AplicaEnCuadre { get; set; }
    public bool Referencia { get; set; }
    public bool Activa { get; set; }
}
