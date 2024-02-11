namespace Domain.Entities
{
    public class Project:BaseEntity
    {
        public User Owner { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public ICollection<Collaborator> Collaborators { get; set; }
        public ICollection<Task> Tasks { get; set; }

    }
}
