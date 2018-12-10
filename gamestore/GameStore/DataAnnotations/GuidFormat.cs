using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DataAnnotations
{
    public class GuidFormat : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                bool isValid = Guid.TryParse(value.ToString(), out var output);
                return isValid && output != Guid.Empty;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
