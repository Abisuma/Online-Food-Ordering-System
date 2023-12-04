using Models;
using System.Diagnostics.Metrics;

namespace DataAccess.Repository.IRepository
{
    public interface IOrder : IGenericRepository<Order>
    {
        //Task<TResult> AddAsyncOrder<TSource,T,TResult>(TSource source);
    }
}