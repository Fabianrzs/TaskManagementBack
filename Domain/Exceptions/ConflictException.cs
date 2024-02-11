namespace Domain.Exceptions
{
    public class ConflictException : AppException
    {
        public ConflictException() { }
        public ConflictException(string message) : base(message) { }
        public ConflictException(string message, System.Exception inner) : base(message, inner) { }
        protected ConflictException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
