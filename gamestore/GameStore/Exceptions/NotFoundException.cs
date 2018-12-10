using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string targetName, object targetParameter)
            : base($"The {targetName} with {targetParameter} is not found.", null)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
