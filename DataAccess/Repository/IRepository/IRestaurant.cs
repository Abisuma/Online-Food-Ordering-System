using Models;
using Models.DTOs.Restaurant;
using System.Diagnostics.Metrics;

namespace DataAccess.Repository.IRepository
{
    public interface IRestaurant : IGenericRepository<Restaurant>
    {
        public Task<RestaurantDTO> GetRestaurantDetails(int id);
    }
}