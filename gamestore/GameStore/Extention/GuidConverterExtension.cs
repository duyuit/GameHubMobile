using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Extention
{
    public static class GuidConverterExtension
    {
        public static Guid ToGuid(this string input)
        {
            bool isValid = Guid.TryParse(input, out var output);
            if (!isValid)
                throw new ArgumentException($"The {nameof(input)} is not in right format");
            return output;
        }
    }
}
