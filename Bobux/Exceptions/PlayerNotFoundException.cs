using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bobux.Exceptions
{
    class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException() : base() { }

        public PlayerNotFoundException(string message) : base(message) { }

        public PlayerNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        protected PlayerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
