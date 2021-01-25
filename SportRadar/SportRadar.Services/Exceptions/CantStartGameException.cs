using System;
using System.Runtime.Serialization;

namespace SportRadar.Services
{
    public class CantStartGameException : Exception
    {
        public CantStartGameException()
        {
        }

        protected CantStartGameException(
            SerializationInfo info,
            StreamingContext context
        )
            : base(info, context)
        {
        }

        public CantStartGameException(string? message)
            : base(message)
        {
        }

        public CantStartGameException(
            string? message,
            Exception? innerException
        )
            : base(message, innerException)
        {
        }
    }
}