using System;
using System.Runtime.Serialization;

namespace SnapCard.Logic
{
    [Serializable]
    public class ExceededDeckLengthException: Exception
    {
        public ExceededDeckLengthException()
        {
        }

        protected ExceededDeckLengthException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ExceededDeckLengthException(string? message) : base(message)
        {
        }

        public ExceededDeckLengthException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}