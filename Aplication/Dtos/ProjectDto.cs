namespace Aplication.Mappers
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public Guid Owner { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
    }
}
