using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConsoleApp1
{
    class LosaDobException : Exception
    {
        public LosaDobException()
        {
        }

        public LosaDobException(string message) : base(message)
        {
        }

        public LosaDobException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LosaDobException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
