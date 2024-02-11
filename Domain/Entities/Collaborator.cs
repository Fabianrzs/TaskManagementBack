namespace Domain.Entities
{
    public class Collaborator : BaseEntity
    {
        public Project Project { get; set; }
        public User User { get; set; }
    }
}
