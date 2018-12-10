using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Exceptions
{
    public class OversizeException : ApplicationException
    {
        public OversizeException(string targetName, int targetParameter)
            : base($"The {targetName} has reached the maximum size of {targetParameter}.", null)
        {
        }

        public OversizeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
