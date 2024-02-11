using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Collaborator : BaseEntity
    {
        public Guid IdProject { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }
        public Guid IdUser { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public bool Owner { get; set; }
    }
}
