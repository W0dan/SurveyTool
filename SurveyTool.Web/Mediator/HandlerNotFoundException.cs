using System;
using System.Runtime.Serialization;

namespace SurveyTool.Web.Mediator
{
    [Serializable]
    internal class HandlerNotFoundException : Exception
    {
        private Type type;

        public HandlerNotFoundException()
        {
        }

        public HandlerNotFoundException(Type type)
        {
            this.type = type;
        }

        public HandlerNotFoundException(string message) : base(message)
        {
        }

        public HandlerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HandlerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}