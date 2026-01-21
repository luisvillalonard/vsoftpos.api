using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Interfaces.Contabilidad;
using Pos.Core.Modelos;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Contabilidad
{
    public class ComprobanteSecuenciaRepositorio : RepositorioGenerico<ComprobanteSecuencia, int>, IComprobanteSecuenciaRepositorio
    {
        internal IQueryable<VwComprobantesSecuencias> _dbQueryView;
        private readonly IMapper _mapper;

        public ComprobanteSecuenciaRepositorio(PosContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dbQueryView = context.Set<VwComprobantesSecuencias>().AsQueryable<VwComprobantesSecuencias>();
        }

        public async Task<ResponseResult> Todas()
        {
            try
            {
                var data = _dbQueryView
                    .AsNoTracking()
                    .AsEnumerable()
                    .OrderBy(opt => opt.Comprobante)
                        .ThenBy(opt => opt.Empresa)
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
