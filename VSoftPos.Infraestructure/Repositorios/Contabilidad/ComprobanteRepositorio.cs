using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Interfaces.Contabilidad;
using Pos.Core.Modelos;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Contabilidad
{
    public class ComprobanteRepositorio : RepositorioGenerico<Comprobante, int>, IComprobanteRepositorio
    {
        internal IQueryable<VwComprobantes> _dbQueryView;
        private readonly IMapper _mapper;

        public ComprobanteRepositorio(PosContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dbQueryView = context.Set<VwComprobantes>().AsQueryable<VwComprobantes>();
        }

        public async Task<ResponseResult> Todos(RequestFilter request)
        {
            try
            {
                var filters = ExpressionBuilder.New<VwComprobantes>();
                if (request is not null && !string.IsNullOrEmpty(request.Filter))
                {
                    string filter = request.Filter.ToLower();
                    filters = item => item.Tipo.ToLower().Contains(filter)
                        || item.Nombre.ToLower().Contains(request.Filter)
                        || item.Prefijo.ToLower().Contains(filter);
                    _dbQueryView = _dbQueryView.Where(filters);
                }

                var data = _dbQueryView
                    .AsNoTracking()
                    .AsEnumerable()
                    .OrderBy(opt => opt.Nombre)
                        .ThenBy(opt => opt.Tipo)
                    .ToArray() ?? [];
                var result = new ResponseResult(data);

                request ??= new();

                // Obtengo el total de registros
                result.Paginacion = new PagingResult()
                {
                    TotalRecords = _dbQueryView.AsNoTracking().Count(),
                    PageSize = request.PageSize,
                    CurrentPage = request.CurrentPage,
                    Filter = request.Filter
                };

                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                return await Task.FromResult(new ResponseResult(false, "Situación inesperada tratando de obtener los datos de los clientes."));
            }
        }
    }
}
