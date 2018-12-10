using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Base
{
   
        public interface IDataRepository { }

        public interface IDataRepository<T> : IDataRepository
            where T : class
        {
            Task<T> GetSingleAsync(Guid id, bool isIncludeRelative = true);
            Task<IEnumerable<T>> GetAllAsync(bool isIncludeRelative = true);
            Func<IQueryable<T>, IIncludableQueryable<T, object>> CreateInclusiveRelatives();
            Task<T> AddAsync(T entity);
            void Remove(T entity);
            void Update(T entity);
        }
    
}
