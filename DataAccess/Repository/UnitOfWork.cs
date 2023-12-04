using AutoMapper;
using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;
        
        public IRestaurant Restaurant { get; private set; }

        public IMenu Menu { get; private set; }

        public IOrder Order { get; private set; }

        public UnitOfWork(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            Restaurant = new RestaurantRepository(_appDbContext, mapper);
            Menu = new MenuRepository(_appDbContext, mapper);
            Order = new OrderRepository(_appDbContext, mapper); 
        }
    }
}
