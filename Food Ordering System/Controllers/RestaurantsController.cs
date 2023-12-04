using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using Models;
using DataAccess.Repository.IRepository;
using Models.DTOs.Restaurant;
using Microsoft.AspNetCore.Authorization;
using Models.DTOs.Menu;

namespace Food_Ordering_System.Controllers
{
    [Route("api/Restaurants")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RestaurantsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // POST: api/Restaurants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RestaurantDTO>> PostRestaurant(CreateRestaurantDTO createRestaurantDTO)
        {
            var restaurant = await _unitOfWork.Restaurant.AddAsync<CreateRestaurantDTO, GetRestaurantDTO>(createRestaurantDTO);
            return CreatedAtAction(nameof(GetRestaurant), new { id = restaurant.Id }, restaurant);
        }

        // GET: api/Restaurant/id
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<GetRestaurantDTO>>GetRestaurant(int id)
        {
           var singleRestaurant = await _unitOfWork.Restaurant.GetAsync<GetRestaurantDTO>(id); 
            return Ok(singleRestaurant);
        }

        //GET: api/Restaurant/id
        //restaurant with its menu
        [HttpGet("GetRestaurantWithMenus{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<RestaurantDTO>> GetRestaurantWithMenus(int id)
        {
            var singleRestaurantWithitsMenu = await _unitOfWork.Restaurant.GetRestaurantDetails(id);
            return Ok(singleRestaurantWithitsMenu);
        }


        // GET: api/Restaurants
        //restaurants without their menus
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
          
            var restaurants =  await _unitOfWork.Restaurant.GetAllAsync<GetRestaurantDTO>();
            return Ok(restaurants);
        }


        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutRestaurant(int id, UpdateRestaurantDTO updateRestaurant)
        {
            try
            {
                await _unitOfWork.Restaurant.UpdateAsync(id, updateRestaurant);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        //// DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {

            await _unitOfWork.Restaurant.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> RestaurantExists(int id)
        {
            return await _unitOfWork.Restaurant.Exists(id);
        }
    }
}
