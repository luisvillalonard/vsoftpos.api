namespace Pos.Core.Dto
{
    public class BadRequestDto
    {
        public string type { get; set; } = null!;
        public string title { get; set; } = null!;
        public int status { get; set; }
        public string traceId { get; set; } = null!;
        public List<string> errors { get; set; } = [];
    }
}
