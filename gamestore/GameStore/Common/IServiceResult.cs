using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Common
{
    public interface IServiceResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        dynamic Payload { get; set; }
    }
}
