using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NoContentException : AppException
    {
        public NoContentException() { }
        public NoContentException(string message) : base(message) { }
        public NoContentException(string message, System.Exception inner) : base(message, inner) { }
        protected NoContentException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
