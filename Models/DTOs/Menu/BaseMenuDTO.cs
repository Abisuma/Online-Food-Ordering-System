using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Menu
{
    public class BaseMenuDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]  
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int RestaurantId { get; set; }
        
    }
}
