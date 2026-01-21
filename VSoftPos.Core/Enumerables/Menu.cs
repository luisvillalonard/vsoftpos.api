using Pos.Core.Attributos;

namespace Pos.Core.Enumerables
{
    public enum Menu
    {
        /* PADRES */
        Ninguno = 0,


        /* EMPRESAS */
        [Menu(Padre = Ninguno, Titulo = "Empresa")]
        Empresas = 100,

        [Menu(Padre = Empresas, Titulo = "Horarios", EndPoint = "empresas/horarios")]
        EmpresasHorarios,

        [Menu(Padre = Empresas, Titulo = "Posiciones", EndPoint = "empresas/posiciones")]
        EmpresasPosiciones,

        [Menu(Padre = Empresas, Titulo = "Empleados", EndPoint = "empresas/empleados")]
        EmpresasEmpleados,

        [Menu(Padre = Empresas, Titulo = "Empresas", EndPoint = "empresas/todas")]
        EmpresasEmpresas,


        /* CONTABILIDAD */
        [Menu(Padre = Ninguno, Titulo = "Contabilidad")]
        Contabilidad = 200,

        [Menu(Padre = Contabilidad, Titulo = "Bancos", EndPoint = "contabilidad/bancos")]
        ContabilidadBancos,

        [Menu(Padre = Contabilidad, Titulo = "Cuentas de Bancos", EndPoint = "contabilidad/bancos/cuentas")]
        ContabilidadCuentasBancos,

        [Menu(Padre = Contabilidad, Titulo = "Comprobantes", EndPoint = "contabilidad/comprobantes")]
        ContabilidadComprobantes,

        [Menu(Padre = Contabilidad, Titulo = "Secuencias de Comprobantes", EndPoint = "contabilidad/comprobantes/secuencias")]
        ContabilidadComprobantesSecuencias,

        [Menu(Padre = Contabilidad, Titulo = "Catalogo de Cuentas", EndPoint = "contabilidad/catalogocc")]
        ContabilidadCatalogoCC,


        /* INVENTARIO */
        [Menu(Padre = Ninguno, Titulo = "Inventario")]
        Inventario = 300,

        [Menu(Padre = Inventario, Titulo = "Almacénes", EndPoint = "inventario/almacenes")]
        InventarioAlmacenes,

        [Menu(Padre = Inventario, Titulo = "Empaques", EndPoint = "inventario/empaques")]
        InventarioEmpaques,

        [Menu(Padre = Inventario, Titulo = "Medidas", EndPoint = "inventario/medidas")]
        InventarioMedidas,

        [Menu(Padre = Inventario, Titulo = "Unidades de Medidas", EndPoint = "inventario/medidas/unidades")]
        InventarioUnidadesMedidas,

        [Menu(Padre = Inventario, Titulo = "Productos", EndPoint = "inventario/productos")]
        InventarioProductos,


        /* COMPRAS */
        [Menu(Padre = Ninguno, Titulo = "Compras")]
        Compras = 400,

        [Menu(Padre = Compras, Titulo = "Suplidores", EndPoint = "compras/suplidores")]
        ComprasSuplidores,

        [Menu(Padre = Compras, Titulo = "Facturas", EndPoint = "compras/facturas")]
        ComprasFacturasHistorico,

        [Menu(Padre = Compras, Titulo = "Cuentas por Pagar", EndPoint = "compras/facturas/cxp")]
        ComprasFacturasCxP,

        [Menu(Padre = Compras, Titulo = "Tipos de Gastos", EndPoint = "compras/gastos/tipos")]
        ComprasGastosTipos,

        [Menu(Padre = Compras, Titulo = "Gastos", EndPoint = "compras/gastos")]
        ComprasGastos,


        /* VENTAS */
        [Menu(Padre = Ninguno, Titulo = "Ventas")]
        Ventas = 500,

        [Menu(Padre = Ventas, Titulo = "Clientes", EndPoint = "ventas/clientes")]
        VentasClientes,

        [Menu(Padre = Ventas, Titulo = "Facturas", EndPoint = "ventas/facturas")]
        VentasFacturasHistorico,

        [Menu(Padre = Ventas, Titulo = "Cuentas por Cobrar", EndPoint = "ventas/facturas/cxc")]
        VentasFacturasCxC,


        /* SEGURIDAD */
        [Menu(Padre = Ninguno, Titulo = "Seguridad")]
        Seguridad = 600,

        [Menu(Padre = Seguridad, Titulo = "Permisos", EndPoint = "seguridad/roles")]
        SeguridadPermisos,

        [Menu(Padre = Seguridad, Titulo = "Usuarios", EndPoint = "seguridad/usuarios")]
        SeguridadUsuarios,


        /* CONFIGURACIONES */
        [Menu(Padre = Ninguno, Titulo = "Configuraciones")]
        Configuraciones = 700,

        [Menu(Padre = Configuraciones, Titulo = "Grupos", EndPoint = "configuraciones/grupos")]
        ConfiguracionesGrupos,

        [Menu(Padre = Configuraciones, Titulo = "Tipos de Factura", EndPoint = "configuraciones/facturas/tipos")]
        ConfiguracionesFacturasTipo,

        [Menu(Padre = Configuraciones, Titulo = "Formas de Pago", EndPoint = "configuraciones/formasPago")]
        ConfiguracionesFormasPago,

        [Menu(Padre = Configuraciones, Titulo = "Condiciones de Pago", EndPoint = "configuraciones/condicionesPago")]
        ConfiguracionesCondicionesPago,

        [Menu(Padre = Configuraciones, Titulo = "Impuestos", EndPoint = "configuraciones/impuestos")]
        ConfiguracionesImpuestos,
    }
}
