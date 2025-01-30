using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoBackend.Application.Interface
{
    public  interface IBusiness<T> where T : class
    {
        Task<HindalcoBackend.Domain.ResponseToken> Generatetoken(HindalcoBackend.Domain.DomainModels.DataModels.UserModel umodel);
        Task<IEnumerable<T>> GetallUserAsync();
        Task<T?> GetUserByEmail(string Email);
        Task<T> AddAsync(T entity);
    }
}
