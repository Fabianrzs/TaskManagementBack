namespace Aplication.Mappers
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public Guid Owner { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public ICollection<CollaboratorDto> Collaborators { get; set; }
        public ICollection<TaskEntityDto> Tasks { get; set; }

    }
}
