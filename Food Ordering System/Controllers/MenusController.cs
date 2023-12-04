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
using DataAccess.Repository;
using Models.DTOs.Menu;
using Models.DTOs.Menu;
using Microsoft.AspNetCore.Authorization;

namespace Food_Ordering_System.Controllers
{
    [Route("api/Menus")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        // POST: api/Menus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<MenuDTO>> PostMenu(BaseMenuDTO menuDTO)
        {
            var menu = await _unitOfWork.Menu.AddAsync<BaseMenuDTO, MenuDTO>(menuDTO);
            return CreatedAtAction(nameof(GetMenu), new { id = menu.Id }, menu);
        }

        // GET: api/Menus/id
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<MenuDTO>> GetMenu(int id)
        {
            var singleMenu = await _unitOfWork.Menu.GetAsync<MenuDTO>(id);
            return Ok(singleMenu);
        }

        // GET: api/Menus
        //all menus
        [HttpGet("GetAllMenu")]
        [Authorize(Roles = "Admin,User")]

        public async Task<ActionResult<IEnumerable<Menu>>> GetMenu()
        {

            var menus = await _unitOfWork.Menu.GetAllAsync<MenuDTO>();
            return Ok(menus);
        }

        // PUT: api/Menus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> PutMenu(int id, MenuDTO updateMenu)
        {
            try
            {
                await _unitOfWork.Menu.UpdateAsync(id, updateMenu);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MenuExists(id))
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


        //// DELETE: api/Menus/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMenu(int id)
        {

            await _unitOfWork.Menu.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> MenuExists(int id)
        {
            return await _unitOfWork.Menu.Exists(id);
        }

    }
}
