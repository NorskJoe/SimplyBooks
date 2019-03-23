using System;
using System.Runtime.Serialization;

namespace SimplyBooks.Services.Genres.Concrete
{
    [Serializable]
    internal class HttpResponseException : Exception
    {
        private object notModified;

        public HttpResponseException()
        {
        }

        public HttpResponseException(object notModified)
        {
            this.notModified = notModified;
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}