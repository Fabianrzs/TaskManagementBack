namespace Aplication.Mappers
{
    public class TaskEntityDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Complete { get; set; } = false;
        public Guid IdProject { get; set; }
    }
}
