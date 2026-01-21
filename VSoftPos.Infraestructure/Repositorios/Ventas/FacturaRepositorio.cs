using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Ventas;
using Pos.Core.Interfaces.Ventas;
using Pos.Core.Modelos;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Ventas
{
    public class FacturaRepositorio : RepositorioGenerico<Factura, long>, IFacturaRepositorio
    {
        public FacturaRepositorio(PosContext context) : base(context) { }

        public override async Task<ResponseResult> PostAsync(Factura factura)
        {
            await using var transaction = await base.context.Database.BeginTransactionAsync();

            try
            {
                base.context.Entry(factura).State = EntityState.Added;
                if (await base.context.SaveChangesAsync() <= 0)
                    return new ResponseResult(false, "No fue posible guardar los datos de la factura.");

                factura.FacturaDetalle = factura.FacturaDetalle
                    .Select(item => { item.FacturaId = factura.Id; return item; })
                    .ToArray();

                foreach (var detalle in factura.FacturaDetalle)
                    base.context.Entry(detalle).State = EntityState.Added;

                if (await base.context.SaveChangesAsync() <= 0)
                {
                    await transaction.RollbackAsync();
                    transaction.Dispose();
                    return new ResponseResult(false, "No fue posible guardar los detalles de la factura.");
                }

                if (factura.FacturaPago.Count > 0)
                {
                    factura.FacturaPago = factura.FacturaPago
                        .Select(item => { item.FacturaId = factura.Id; return item; })
                        .ToArray();

                    foreach (var detalle in factura.FacturaPago)
                        base.context.Entry(detalle).State = EntityState.Added;

                    if (await base.context.SaveChangesAsync() <= 0)
                    {
                        await transaction.RollbackAsync();
                        transaction.Dispose();
                        return new ResponseResult(false, "No fue posible guardar el pago de la factura.");
                    }
                }

                // Guardo la transaccion completa
                await transaction.CommitAsync();
            }
            catch (Exception err)
            {
                transaction.Rollback();
                transaction.Dispose();
                return new ResponseResult(false, $"Error. {err.Message} {(err.InnerException == null ? string.Empty : err.InnerException.Message)}".Trim());
            }

            return new ResponseResult(factura);
        }

        public async Task<ResponseResult> PostPagoAsync(FacturaPago[] pagos)
        {
            var result = await base.GetByIdAsync(pagos.First().FacturaId);
            if (!result.Ok)
                return result;

            var factura = result.Datos as Factura;
            if (factura == null)
                return new ResponseResult(false, "Código de factura no encontrado.");

            await using var transaction = await base.context.Database.BeginTransactionAsync();

            try
            {
                foreach (var detalle in pagos)
                    base.context.Entry(detalle).State = EntityState.Added;

                if (await base.context.SaveChangesAsync() <= 0)
                {
                    await transaction.RollbackAsync();
                    transaction.Dispose();
                    return new ResponseResult(false, "No fue posible guardar el pago de la factura.");
                }

                // Actualizo el monto pagado
                var pagado = factura.Pagado + pagos.Sum(x => x.Monto);
                var abierta = !(pagado > (factura.Total - factura.Pagado));
                factura.Abierta = abierta;
                factura.Pagado = !abierta ? factura.Total : pagado;

                base.context.Entry(factura).State = EntityState.Modified;
                if (await base.context.SaveChangesAsync() <= 0)
                {
                    await transaction.RollbackAsync();
                    transaction.Dispose();
                    return new ResponseResult(false, "No fue posible completar el pago de la factura.");
                }

                // Guardo la transaccion completa
                await transaction.CommitAsync();
            }
            catch (Exception err)
            {
                transaction.Rollback();
                transaction.Dispose();
                return new ResponseResult(false, $"Error. {err.Message} {(err.InnerException == null ? string.Empty : err.InnerException.Message)}".Trim());
            }

            return new ResponseResult();
        }
    }
}
