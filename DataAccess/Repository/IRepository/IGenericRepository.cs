using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
       
        Task<TResult> GetAsync<TResult>(int? id);

        Task<List<TResult>> GetAllAsync<TResult>();
       
        Task DeleteAsync(int? id);

        Task UpdateAsync<TSource>(int id, TSource source) where TSource : IBaseDTO;
        Task<TResult> AddAsync<TSource,TResult>(TSource source);

       // Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameter queryParameter);
        Task<bool> Exists(int id);
    }
}
