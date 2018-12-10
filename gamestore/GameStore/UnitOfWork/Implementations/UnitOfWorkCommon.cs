using GameStore.Data;
using GameStore.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.UnitOfWork.Implementations
{
    public class UnitOfWorkCommon : IUnitOfWorkCommon
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWorkCommon(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
