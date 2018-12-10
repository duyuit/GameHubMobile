using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Exceptions
{
    public class NotSupportException : ApplicationException
    {
        public NotSupportException(string targetName, string targetExtension)
            : base($"The {targetName} with extension {targetExtension} is not supported.", null)
        {
        }

        public NotSupportException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
