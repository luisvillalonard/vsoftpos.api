using Microsoft.Extensions.DependencyInjection;
using Pos.Core.Interfaces;
using Pos.Core.Interfaces.Auxiliares;
using Pos.Core.Interfaces.Compras;
using Pos.Core.Interfaces.Configuraciones;
using Pos.Core.Interfaces.Contabilidad;
using Pos.Core.Interfaces.Empresas;
using Pos.Core.Interfaces.Inventario;
using Pos.Core.Interfaces.Seguridad;
using Pos.Core.Interfaces.Ventas;
using Pos.Infraestructure.Repositorios;
using Pos.Infraestructure.Repositorios.Auxiliares;
using Pos.Infraestructure.Repositorios.Compras;
using Pos.Infraestructure.Repositorios.Configuraciones;
using Pos.Infraestructure.Repositorios.Contabilidad;
using Pos.Infraestructure.Repositorios.Empresas;
using Pos.Infraestructure.Repositorios.Inventario;
using Pos.Infraestructure.Repositorios.Seguridad;
using Pos.Infraestructure.Repositorios.Ventas;
using Pos.Infraestructure.Services;

namespace Pos.Infraestructure.Starup.Services
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            /* Genericos */
            services.AddTransient(typeof(IRepositorioGenerico<,>), typeof(RepositorioGenerico<,>));

            /* Auxiliares */
            services.AddTransient(typeof(IBilleteRepositorio), typeof(BilleteRepositorio));
            services.AddTransient(typeof(IGeneroRepositorio), typeof(GeneroRepositorio));

            /* Empresas */
            services.AddTransient(typeof(IEmpleadoRepositorio), typeof(EmpleadoRepositorio));
            services.AddTransient(typeof(IEmpresaRepositorio), typeof(EmpresaRepositorio));
            services.AddTransient(typeof(IHorarioRepositorio), typeof(HorarioRepositorio));
            services.AddTransient(typeof(IPosicionRepositorio), typeof(PosicionRepositorio));

            /* Inventario */
            services.AddTransient(typeof(IAlmacenRepositorio), typeof(AlmacenRepositorio));
            services.AddTransient(typeof(IAlmacenEntradaRepositorio), typeof(AlmacenEntradaRepositorio));
            services.AddTransient(typeof(IAlmacenSalidaRepositorio), typeof(AlmacenSalidaRepositorio));
            services.AddTransient(typeof(IEmpaqueRepositorio), typeof(EmpaqueRepositorio));
            services.AddTransient(typeof(IMedidaRepositorio), typeof(MedidaRepositorio));
            services.AddTransient(typeof(IProductoRepositorio), typeof(ProductoRepositorio));
            services.AddTransient(typeof(IStockRepositorio), typeof(StockRepositorio));
            services.AddTransient(typeof(IUnidadRepositorio), typeof(UnidadRepositorio));

            /* Compras */
            services.AddTransient(typeof(ICompraRepositorio), typeof(CompraRepositorio));
            services.AddTransient(typeof(ICompraPagoRepositorio), typeof(CompraPagoRepositorio));
            services.AddTransient(typeof(ISuplidorRepositorio), typeof(SuplidorRepositorio));
            services.AddTransient(typeof(IGastoRepositorio), typeof(GastoRepositorio));
            services.AddTransient(typeof(IGastoTipoRepositorio), typeof(GastoTipoRepositorio));

            /* Ventas */
            services.AddTransient(typeof(IClienteRepositorio), typeof(ClienteRepositorio));
            services.AddTransient(typeof(IFacturaRepositorio), typeof(FacturaRepositorio));
            services.AddTransient(typeof(IFacturaTipoRepositorio), typeof(FacturaTipoRepositorio));

            /* Configuraciones */
            services.AddTransient(typeof(ICondicionPagoRepositorio), typeof(CondicionPagoRepositorio));
            services.AddTransient(typeof(IConfigsRepositorio), typeof(ConfigsRepositorio));
            services.AddTransient(typeof(IFormaPagoRepositorio), typeof(FormaPagoRepositorio));
            services.AddTransient(typeof(IGrupoRepositorio), typeof(GrupoRepositorio));

            /* Contabilidad */
            services.AddTransient(typeof(IBancoRepositorio), typeof(BancoRepositorio));
            services.AddTransient(typeof(ICatalogoCcRepositorio), typeof(CatalogoCcRepositorio));
            services.AddTransient(typeof(IComprobanteRepositorio), typeof(ComprobanteRepositorio));
            services.AddTransient(typeof(IComprobanteTipoRepositorio), typeof(ComprobanteTipoRepositorio));
            services.AddTransient(typeof(IComprobanteSecuenciaRepositorio), typeof(ComprobanteSecuenciaRepositorio));
            services.AddTransient(typeof(ICuentaBancoRepositorio), typeof(CuentaBancoRepositorio));
            services.AddTransient(typeof(IImpuestoRepositorio), typeof(ImpuestoRepositorio));

            /* Seguridad */
            services.AddTransient(typeof(IPermisoRepositorio), typeof(PermisoRepositorio));
            services.AddTransient(typeof(IRolRepositorio), typeof(RolRepositorio));
            services.AddTransient(typeof(IUsuarioRepositorio), typeof(UsuarioRepositorio));

            /* Envio de Correos */
            services.AddTransient(typeof(IMailService), typeof(MailService));

            return services;
        }
    }
}
