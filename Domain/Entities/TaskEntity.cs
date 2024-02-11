using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class TaskEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Complete { get; set; } = false;
        public Guid IdManage { get; set; }
        [JsonIgnore]
        public User Manage { get; set; }
        public Guid IdProject { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }
    }
}
