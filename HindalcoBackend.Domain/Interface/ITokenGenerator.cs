using HindalcoBackend.Application.Interface;
using HindalcoBackend.Business;
using HindalcoBackend.Domain;
using HindalcoBackend.Domain.DomainModels.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoBackend.Domain.Interface
{
    public class ITokenGenerator<T> : IBusiness<T> where T : class
    {

        private readonly appDBontext _appdbContext;
        private readonly DbSet<T> _dbSet;
        public ITokenGenerator(appDBontext appDBontext)
        {
            _appdbContext= appDBontext;
            _dbSet = _appdbContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetallAsync() => await _dbSet.ToListAsync();
        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);


    }
}
