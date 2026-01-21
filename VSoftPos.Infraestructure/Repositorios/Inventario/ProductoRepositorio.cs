using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Inventario;
using Pos.Core.Interfaces.Inventario;
using Pos.Core.Modelos;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Inventario
{
    public class ProductoRepositorio : RepositorioGenerico<Producto, int>, IProductoRepositorio
    {
        internal readonly IMapper _mapper;
        internal IQueryable<VwProductos> _dbQueryView;

        public ProductoRepositorio(PosContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dbQueryView = context.Set<VwProductos>().AsQueryable<VwProductos>();
        }

        public async Task<ResponseResult> Todos(RequestFilter request)
        {
            try
            {
                var filters = ExpressionBuilder.New<VwProductos>();
                if (request is not null && !string.IsNullOrEmpty(request.Filter))
                {
                    string filter = request.Filter;
                    filters = item => item.Nombre.ToLower().Contains(filter)
                        || (item.Codigo ??  string.Empty).ToLower().Contains(filter)
                        || (item.CodigoBarra ??  string.Empty).ToLower().Contains(filter)
                        || item.Grupo.ToLower().Contains(filter)
                        || (item.Impuesto ??  string.Empty).ToLower().Contains(filter);
                    _dbQueryView = _dbQueryView.Where(filters);
                }

                request ??= new();

                var data = _dbQueryView
                    .AsNoTracking()
                    .AsEnumerable()
                    .OrderBy(opt => opt.Descripcion)
                    .Skip((request.CurrentPage - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToArray() ?? [];

                var result = new ResponseResult(data)
                {
                    // Obtengo el total de registros
                    Paginacion = new PagingResult()
                    {
                        TotalRecords = _dbQueryView.AsNoTracking().Count(),
                        PageSize = request.PageSize,
                        CurrentPage = request.CurrentPage,
                        Filter = request.Filter
                    }
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
