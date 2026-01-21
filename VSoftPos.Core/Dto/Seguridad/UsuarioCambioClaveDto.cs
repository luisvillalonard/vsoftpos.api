namespace Pos.Core.Dto.Seguridad
{
    public class UsuarioCambioClaveDto
    {
        public required string Acceso { get; set; }
        public required string PasswordOld { get; set; }
        public required string PasswordNew { get; set; }
        public required string PasswordConfirm { get; set; }
    }
}
