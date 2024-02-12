using Domain.Entities;
using System.Text.Json.Serialization;

namespace Aplication.Mappers
{
    public class CommentDto
    {
        public Guid Owner { get; set; }
        public Guid Relation { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public Guid Thread { get; set; }
        [JsonIgnore]
        public List<Comment>? Responses { get; set; }
    }
}
