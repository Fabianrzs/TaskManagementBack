namespace Domain.Entities
{
    public class TaskEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public User Manage { get; set; }
        public Project Project { get; set; }
    }
}
