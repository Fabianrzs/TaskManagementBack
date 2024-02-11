namespace Domain.Entities
{
    public class Comment: BaseMongo
    {
        public Guid Owner { get; set; }
        public Guid Relation { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public Guid Thread { get; set; }
        public List<Comment> Responses { get; set; }
    }
}
