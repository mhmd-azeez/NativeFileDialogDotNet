using System;
using System.Runtime.Serialization;

namespace NativeFileDialogDotNet
{
    public class NfdException : Exception
    {
        public NfdException()
        {
        }

        public NfdException(string message) : base(message)
        {
        }

        public NfdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NfdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
