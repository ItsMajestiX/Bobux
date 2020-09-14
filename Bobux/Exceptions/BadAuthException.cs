using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bobux.Exceptions
{
    class BadAuthException : Exception
    {
        public BadAuthException() : base() { }

        public BadAuthException(string message) : base(message) { }

        public BadAuthException(string message, Exception innerException) : base(message, innerException) { }

        protected BadAuthException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
