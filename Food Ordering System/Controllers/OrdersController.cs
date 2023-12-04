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
using Models.DTOs.Order;
using Models.DTOs.Menu;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Drawing;
using System.Security.Claims;
using Models.DTOs.Restaurant;
using AutoMapper;

namespace Food_Ordering_System.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        
        private readonly IUnitOfWork _unitOfWork;  
        //private readonly IMapper _mapper;    

        public OrdersController( IUnitOfWork unitOfWork, IMapper mapper)
        { 
            _unitOfWork = unitOfWork;
             //_mapper = mapper;  
        }


        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<OrderDTO>> PostOrder([FromBody] BaseOrderDTO orderDTO)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return BadRequest("User ID not provided or invalid");
            }

            orderDTO.UserId = userId;   

            var order = await _unitOfWork.Order.AddAsync<BaseOrderDTO,OrderDTO>(orderDTO);

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }



        
        // get: api/orders/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await _unitOfWork.Order.GetAsync<OrderDTO>(id);
            return Ok(order);
        }



        [HttpGet("GetAllOrders")]
        [Authorize(Roles = "Admin,User")]

        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {

            var menus = await _unitOfWork.Order.GetAllAsync<MenuDTO>();
            return Ok(menus);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> PutOrder(int id, OrderDTO updateOrder)
        {
            try
            {
                await _unitOfWork.Order.UpdateAsync(id, updateOrder);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await OrderExists(id))
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


        //// DELETE: api/Orders/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteOrder(int id)
        {

            await _unitOfWork.Order.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> OrderExists(int id)
        {
            return await _unitOfWork.Order.Exists(id);
        }

    }
}
