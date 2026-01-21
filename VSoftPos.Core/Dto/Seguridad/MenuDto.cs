namespace Pos.Core.Dto.Seguridad
{
    public class MenuDto
    {
        public int Id { get; set; }
        public int Padre { get; set; }
        public required string Titulo { get; set; }
        public string? EndPoint { get; set; }
        public MenuDto[]? Items { get; set; }
    }
}
