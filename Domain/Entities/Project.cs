using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Project:BaseEntity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        [JsonIgnore]
        public ICollection<Collaborator> Collaborators { get; set; }
        [JsonIgnore]
        public ICollection<TaskEntity> Tasks { get; set; }

    }
}
