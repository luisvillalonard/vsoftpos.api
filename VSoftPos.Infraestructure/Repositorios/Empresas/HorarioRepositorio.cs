using AutoMapper;
using Microsoft.AspNetCore.Http;
using Pos.Core.Entidades.Empresas;
using Pos.Core.Interfaces.Empresas;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Empresas
{
    public class HorarioRepositorio : RepositorioGenerico<Horario, int>, IHorarioRepositorio
    {
        private readonly PosContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HorarioRepositorio(PosContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        //public override async Task<ResponseResult> PostAsync(Horario entity)
        //{
        //    using (var transaction = await _context.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            var result = await _httpContextAccessor.HttpContext?.Request.SaveNewLog()!;
        //            if (!result.Ok)
        //                return result;

        //            var log = result.Datos as UsuarioLog;
        //            if (log == null)
        //                return new ResponseResult(false, "No fue posible establecer una auditoría para la transacción.");

        //            entity.LogId = log.Id;

        //            await _context.Horario.AddAsync(entity);
        //            if (await _context.SaveChangesAsync() == 0)
        //                return new ResponseResult(false, "Situación inesperada tratando de guardar los datos del horario.");

        //            await transaction.CommitAsync();

        //            return result;
        //        }
        //        catch (Exception)
        //        {
        //            transaction.Rollback();
        //            return new ResponseResult(false, "Situación inesperada tratando de guardar los datos de la entidad.");
        //        }
        //    }
        //}

        //public override async Task<ResponseResult> PutAsync(Horario entity)
        //{
        //    using (var transaction = await _context.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            var user = await _httpContextAccessor.HttpContext?.Request.GetUser()!;
        //            if (user == null)
        //                return new ResponseResult(false, "No fue posible establecer el usuario para la transacción.");

        //            var itemUpdated = await _context.Horario
        //                .AsNoTracking()
        //                .Include(item => item.Empresa)
        //                .Include(item => item.Log)
        //                .SingleOrDefaultAsync(item => item.Id == entity.Id);
        //            if (itemUpdated == null)
        //                return new ResponseResult(false, "Código de horario no encontrado.");

        //            itemUpdated.Nombre = entity.Nombre;
        //            itemUpdated.HoraInicio = entity.HoraInicio;
        //            itemUpdated.HoraFin = entity.HoraFin;
        //            itemUpdated.EmpresaId = entity.EmpresaId;
        //            itemUpdated.Activo = entity.Activo;

        //            itemUpdated.Log.ActualizaFecha = DateTime.Now;
        //            itemUpdated.Log.ActualizaUsuarioId = user?.Id;

        //            _context.Horario.Update(itemUpdated);
        //            if (await _context.SaveChangesAsync() == 0)
        //                return new ResponseResult(false, "Situación inesperada tratando de actualizar los datos del horario.");

        //            await transaction.CommitAsync();

        //            return result;
        //        }
        //        catch (Exception)
        //        {
        //            transaction.Rollback();
        //            return new ResponseResult(false, "Situación inesperada tratando de actualizar los datos de la entidad.");
        //        }
        //    }
        //}
    }
}
