using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Ventas;
using Pos.Core.Interfaces.Ventas;
using Pos.Core.Modelos;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Ventas
{
    public class ClienteRepositorio : RepositorioGenerico<Cliente, int>, IClienteRepositorio
    {
        public ClienteRepositorio(PosContext context) : base(context) { }

        public override async Task<ResponseResult> PostAsync(Cliente cliente)
        {
            await using var transaction = await base.context.Database.BeginTransactionAsync();

            try
            {
                base.context.Entry(cliente).State = EntityState.Added;
                if (await base.context.SaveChangesAsync() <= 0)
                    return new ResponseResult(false, "No fue posible guardar los datos del cliente.");

                // Guardo el credito del cliente
                if (cliente.Credito.Count > 0)
                {
                    cliente.Credito = cliente.Credito
                        .Select(item => { item.ClienteId = cliente.Id; return item; })
                        .ToArray();

                    foreach (var credito in cliente.Credito)
                        base.context.Entry(credito).State = EntityState.Added;

                    if (await base.context.SaveChangesAsync() <= 0)
                    {
                        await transaction.RollbackAsync();
                        transaction.Dispose();
                        return new ResponseResult(false, "No fue posible guardar el creédito del cliente.");
                    }
                }

                // Guardo la transaccion completa
                await transaction.CommitAsync();
            }
            catch (Exception err)
            {
                await transaction.RollbackAsync();
                transaction.Dispose();
                result = new ResponseResult(false, $"Error. {err.Message} {(err.InnerException == null ? string.Empty : err.InnerException.Message)}".Trim());
            }

            return new ResponseResult();
        }

        public override async Task<ResponseResult> PutAsync(Cliente cliente)
        {
            await using var transaction = await base.context.Database.BeginTransactionAsync();

            try
            {
                base.context.Entry(cliente).State = EntityState.Modified;
                if (await base.context.SaveChangesAsync() <= 0)
                    return new ResponseResult(false, "No fue posible guardar los datos del cliente.");

                // Guardo el credito del cliente
                if (cliente.Credito.Count > 0)
                {
                    cliente.Credito = cliente.Credito
                        .Select(item => { item.ClienteId = cliente.Id; return item; })
                        .ToArray();

                    foreach (var credito in cliente.Credito)
                        base.context.Entry(credito).State = credito.Id == 0 ? EntityState.Added : EntityState.Modified;

                    if (await base.context.SaveChangesAsync() <= 0)
                    {
                        await transaction.RollbackAsync();
                        transaction.Dispose();
                        return new ResponseResult(false, "No fue posible guardar el creédito del cliente.");
                    }
                }

                // Guardo la transaccion completa
                await transaction.CommitAsync();
            }
            catch (Exception err)
            {
                await transaction.RollbackAsync();
                transaction.Dispose();
                result = new ResponseResult(false, $"Error. {err.Message} {(err.InnerException == null ? string.Empty : err.InnerException.Message)}".Trim());
            }

            return new ResponseResult();
        }
    }
}
