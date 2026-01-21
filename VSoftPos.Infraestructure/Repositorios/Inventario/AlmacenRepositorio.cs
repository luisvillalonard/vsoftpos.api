using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Inventario;
using Pos.Core.Entidades.Ventas;
using Pos.Core.Interfaces.Inventario;
using Pos.Core.Modelos;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Inventario
{
    public class AlmacenRepositorio : RepositorioGenerico<Almacen, int>, IAlmacenRepositorio
    {
        internal readonly IMapper _mapper;
        internal readonly IQueryable<VwAlmacenes> _dbQueryView;

        public AlmacenRepositorio(PosContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dbQueryView = context.Set<VwAlmacenes>().AsQueryable<VwAlmacenes>();
        }

        public async Task<ResponseResult> Todos()
        {
            try
            {
                var data = _dbQueryView
                    .AsNoTracking()
                    .AsEnumerable()
                    .OrderBy(opt => opt.Nombre)
                    .ToArray() ?? [];
                var result = new ResponseResult(data);

                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                return await Task.FromResult(new ResponseResult(false, "Situación inesperada tratando de obtener los datos de los clientes."));
            }
        }
    }
}
