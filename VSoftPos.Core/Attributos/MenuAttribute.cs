using Pos.Core.Enumerables;

namespace Pos.Core.Attributos
{
    public class MenuAttribute : Attribute
    {
        public Menu Padre { get; set; }
        public required string Titulo { get; set; }
        public string? EndPoint { get; set; }
    }
}
