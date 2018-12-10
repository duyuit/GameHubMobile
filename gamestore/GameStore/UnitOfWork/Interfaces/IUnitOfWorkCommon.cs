using GameStore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkCommon : IDisposable
    {
        Task<bool> CompleteAsync();
    }
}
