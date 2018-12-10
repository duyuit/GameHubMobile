using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Exceptions
{
    public class SaveFailedException : ApplicationException
    {
        public SaveFailedException(string targetName)
            : base($"The {targetName} can not be saved.", null)
        {
        }

        public SaveFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
