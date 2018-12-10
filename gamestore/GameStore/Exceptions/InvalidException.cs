using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Exceptions
{
    public class InvalidException : ApplicationException
    {
        public InvalidException(string targetName)
            : base($"The {targetName} is invalid.")
        {

        }

        public InvalidException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
