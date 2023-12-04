using AutoMapper;
using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrder
    {
        private AppDbContext _db;
        private readonly IMapper _mapper; 
        public OrderRepository(AppDbContext db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper; 
        }

        //public async Task<TResult> AddAsyncOrder<TSource, T, TResult>(TSource source)
        //{
        //    var entity = _mapper.Map<T>(source);

        //    await _db.AddAsync(entity);
        //    await _db.SaveChangesAsync();

        //    return _mapper.Map<TResult>(entity);
        //}
    }
}
