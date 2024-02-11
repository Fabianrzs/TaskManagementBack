﻿namespace Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid Owner { get; set; }
        public Guid Relation { get; set; }
        public string Message { get; set; }
        public List<Comment> Responses { get; set; }
    }
}