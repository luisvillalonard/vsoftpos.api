namespace Pos.Core.Dto.Configuraciones;

public partial class GrupoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public bool Cliente { get; set; }
    public bool Suplidor { get; set; }
    public bool Producto { get; set; }
    public bool Servicio { get; set; }
    public bool Activo { get; set; }
}
