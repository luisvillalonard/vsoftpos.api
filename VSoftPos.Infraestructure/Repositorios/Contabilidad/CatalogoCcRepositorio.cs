using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Interfaces.Contabilidad;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Contabilidad
{
    public class CatalogoCcRepositorio : RepositorioGenerico<CatalogoCc, int>, ICatalogoCcRepositorio
    {
        public CatalogoCcRepositorio(PosContext context) : base(context) { }
    }
}
