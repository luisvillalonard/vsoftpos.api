using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Interfaces.Configuraciones;
using Pos.Infraestructure.Contexto;

namespace Pos.Infraestructure.Repositorios.Configuraciones
{
    public class ConfigsRepositorio : RepositorioGenerico<Configs, int>, IConfigsRepositorio
    {
        public ConfigsRepositorio(PosContext context) : base(context) { }
    }
}
