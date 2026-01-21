namespace Pos.Core.Dto.Configuraciones;

public partial class ConfigsDto
{
    public string Id { get; set; } = null!;
    public int? ClienteGenericoId { get; set; }
    public int? CompraDiasAnularFactura { get; set; }
    public int? InventarioDiasAnularCompra { get; set; }
    public int? FacturaDiasAnularFactura { get; set; }
    public bool? FacturaModificaPrecioEnVenta { get; set; }
    public string? FacturaNota1 { get; set; }
    public string? FacturaNota2 { get; set; }
    public string? FacturaNota3 { get; set; }
    public string? FacturaNota4 { get; set; }
    public string? FacturaNota5 { get; set; }
}
