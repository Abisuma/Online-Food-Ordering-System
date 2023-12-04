using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTOs.Menu;

namespace Models.DTOs.Restaurant
{
    public class RestaurantDTO:BaseRestaurantDTO
    {
        public int Id { get; set; }
        public List<MenuDTO>? Menu { get; set; }

    }
}
