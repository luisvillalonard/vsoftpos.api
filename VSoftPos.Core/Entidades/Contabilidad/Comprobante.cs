using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Empresas;
using Pos.Core.Entidades.Ventas;

namespace Pos.Core.Entidades.Contabilidad;

public partial class Comprobante
{
    [Key]
    public int Id { get; set; }

    public int TipoId { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(500)]
    public string? Descripcion { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Prefijo { get; set; } = null!;

    public bool Exento { get; set; }

    public int EmpresaId { get; set; }

    public bool Activo { get; set; }

    [InverseProperty("Comprobante")]
    public virtual ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();

    [InverseProperty("Comprobante")]
    public virtual ICollection<ComprobanteSecuencia> ComprobanteSecuencia { get; set; } = new List<ComprobanteSecuencia>();

    [ForeignKey("EmpresaId")]
    [InverseProperty("Comprobante")]
    public virtual Empresa Empresa { get; set; } = null!;

    [InverseProperty("Comprobante")]
    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();

    [ForeignKey("TipoId")]
    [InverseProperty("Comprobante")]
    public virtual ComprobanteTipo Tipo { get; set; } = null!;
}
