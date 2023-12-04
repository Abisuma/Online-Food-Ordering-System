using AutoMapper;
using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs.Restaurant;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurant
    {
        private AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public RestaurantRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RestaurantDTO> GetRestaurantDetails(int id)
        {

            var restaurant = _dbContext.Restaurants
         .Include(u => u.Menu)
         .AsEnumerable() // Materialize the query before projection
         .FirstOrDefault(u => u.Id == id);

            if (restaurant == null)
            {
                return null; // Return null if the restaurant is not found
            }

            return _mapper.Map<RestaurantDTO>(restaurant);
        }
    }
}
