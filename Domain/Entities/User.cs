using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "User";
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Collaborator> Collaborators { get; set;}
        [JsonIgnore]
        public ICollection<TaskEntity> Tasks { get; set; }
    }
}
