using Models.DTOs.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Restaurant
{
    public class UpdateRestaurantDTO:BaseRestaurantDTO, IBaseDTO
    {
        public int Id { get; set; } 
    }
}
