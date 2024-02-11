namespace Aplication.Mappers
{
    public class TaskEntityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public UserDto Manage { get; set; }
    }
}
