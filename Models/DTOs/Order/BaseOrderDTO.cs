using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Order
{
    public class BaseOrderDTO
    {
        public int RestaurantId { get; set; }
        [ForeignKey(nameof(RestaurantId))]
        public double Quantity { get; set; }
        public int MenuID { get; set; }
        public string? UserId { get; set; }
    }
    
}
