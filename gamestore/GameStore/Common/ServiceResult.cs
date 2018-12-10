using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Common
{
    public class ServiceResult : IServiceResult
    {
        public ServiceResult(bool isSuccess = true, string message = default(string), dynamic payload = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Payload = payload;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public dynamic Payload { get; set; }
    }
}
