using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Exceptions
{
    public class NullOrEmptyException : ApplicationException
    {
        public NullOrEmptyException(string targetName, object targetParameter)
            : base($"The {targetName} with {targetParameter} is null or empty.", null)
        {
        }

        public NullOrEmptyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
