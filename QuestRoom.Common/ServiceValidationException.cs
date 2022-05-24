using System.Runtime.Serialization;

namespace QuestRoom.BusinessLogic
{
    [Serializable]
    public class ServiceValidationException : Exception
    {
        public ServiceValidationException()
        {
        }

        public ServiceValidationException(string? message) : base(message)
        {
        }

        public ServiceValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ServiceValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}