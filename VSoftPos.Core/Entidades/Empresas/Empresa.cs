using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Inventario;
using Pos.Core.Entidades.Compras;
using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Entidades.Seguridad;
using Pos.Core.Entidades.Ventas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entidades.Empresas;

[Index("EmpresaId", Name = "IDX_Empresa_EmpresaId")]
public partial class Empresa
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Nombre { get; set; } = null!;

    [Column("RNC")]
    [StringLength(20)]
    [Unicode(false)]
    public string Rnc { get; set; } = null!;

    [StringLength(150)]
    public string Direccion { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? WebSite { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string? Fax { get; set; }

    [StringLength(75)]
    [Unicode(false)]
    public string? Correo { get; set; }

    public long? LogoId { get; set; }

    public bool Principal { get; set; }

    public int? EmpresaId { get; set; }

    public bool Activa { get; set; }

    [InverseProperty("Empresa")]
    public virtual ICollection<Almacen> Almacen { get; set; } = new List<Almacen>();

    [InverseProperty("Empresa")]
    public virtual ICollection<Compra> Compra { get; set; } = new List<Compra>();

    [InverseProperty("Empresa")]
    public virtual ICollection<Comprobante> Comprobante { get; set; } = new List<Comprobante>();

    [InverseProperty("Empresa")]
    public virtual ICollection<ComprobanteSecuencia> ComprobanteSecuencia { get; set; } = new List<ComprobanteSecuencia>();

    [InverseProperty("Empresa")]
    public virtual ICollection<Cotizacion> Cotizacion { get; set; } = new List<Cotizacion>();

    [InverseProperty("Empresa")]
    public virtual ICollection<CuentaBanco> CuentaBanco { get; set; } = new List<CuentaBanco>();

    [InverseProperty("Empresa")]
    public virtual ICollection<Empleado> Empleado { get; set; } = new List<Empleado>();

    [InverseProperty("Empresa")]
    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();

    [InverseProperty("Empresa")]
    public virtual ICollection<Gasto> Gasto { get; set; } = new List<Gasto>();

    [InverseProperty("Empresa")]
    public virtual ICollection<Horario> Horario { get; set; } = new List<Horario>();

    [ForeignKey("LogoId")]
    [InverseProperty("Empresa")]
    public virtual Anexo? Logo { get; set; }

    [InverseProperty("Empresa")]
    public virtual ICollection<Posicion> Posicion { get; set; } = new List<Posicion>();

    [InverseProperty("Empresa")]
    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
