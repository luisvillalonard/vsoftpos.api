using Pos.Core.Dto.Seguridad;
using Pos.Core.Entidades.Seguridad;
using Pos.Core.Modelos;

namespace Pos.Core.Interfaces.Seguridad
{
    public interface IUsuarioRepositorio : IRepositorioGenerico<Usuario, int>
    {
        Task<ResponseResult> ValidarAsync(LoginDto item);
        Task<ResponseResult> PostCambiarClaveAsync(UsuarioCambioClaveDto item);
    }
}
