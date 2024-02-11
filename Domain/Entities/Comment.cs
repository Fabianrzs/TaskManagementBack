namespace Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public User Owner { get; set; }
        public Guid Relation { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public List<Comment> Responses { get; set; }
    }
}
