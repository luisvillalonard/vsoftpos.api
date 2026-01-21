using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pos.Core.Entidades.Configuraciones;

public partial class Configs
{
    [Key]
    [StringLength(50)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    public int? ClienteGenericoId { get; set; }

    [Column("Compra_DiasAnularFactura")]
    public int? CompraDiasAnularFactura { get; set; }

    [Column("Inventario_DiasAnularCompra")]
    public int? InventarioDiasAnularCompra { get; set; }

    [Column("Factura_DiasAnularFactura")]
    public int? FacturaDiasAnularFactura { get; set; }

    [Column("Factura_ModificaPrecioEnVenta")]
    public bool? FacturaModificaPrecioEnVenta { get; set; }

    [Column("Factura_Nota1")]
    [StringLength(250)]
    public string? FacturaNota1 { get; set; }

    [Column("Factura_Nota2")]
    [StringLength(250)]
    public string? FacturaNota2 { get; set; }

    [Column("Factura_Nota3")]
    [StringLength(250)]
    public string? FacturaNota3 { get; set; }

    [Column("Factura_Nota4")]
    [StringLength(250)]
    public string? FacturaNota4 { get; set; }

    [Column("Factura_Nota5")]
    [StringLength(250)]
    public string? FacturaNota5 { get; set; }
}
