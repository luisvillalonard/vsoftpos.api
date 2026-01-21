using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Entidades.Contabilidad;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Ventas;

public partial class Cliente
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "date")]
    public DateTime FechaIngreso { get; set; }

    public bool EsEmpresa { get; set; }

    public bool Generico { get; set; }

    [StringLength(200)]
    public string Nombre { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string? Cedula { get; set; }

    [Column("RNC")]
    [StringLength(9)]
    [Unicode(false)]
    public string? Rnc { get; set; }

    [StringLength(200)]
    public string? Direccion { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Correo { get; set; }

    public int? CondicionPagoId { get; set; }

    public int? ComprobanteId { get; set; }

    public bool Activo { get; set; }

    [ForeignKey("ComprobanteId")]
    [InverseProperty("Cliente")]
    public virtual Comprobante? Comprobante { get; set; }

    [ForeignKey("CondicionPagoId")]
    [InverseProperty("Cliente")]
    public virtual CondicionPago? CondicionPago { get; set; }

    [InverseProperty("Cliente")]
    public virtual ICollection<Cotizacion> Cotizacion { get; set; } = new List<Cotizacion>();

    [InverseProperty("Cliente")]
    public virtual ICollection<Credito> Credito { get; set; } = new List<Credito>();

    [InverseProperty("Cliente")]
    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();
}
