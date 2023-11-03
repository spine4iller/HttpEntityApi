using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

[assembly:InternalsVisibleTo("Api.Tests")]
namespace Api.Infrastructure.Exceptions
{
    [Serializable]
    internal class EntityMissingException : Exception
    {
        public EntityMissingException()
        {
        }

        public EntityMissingException(string? message) : base(message)
        {
        }

        public EntityMissingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EntityMissingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}