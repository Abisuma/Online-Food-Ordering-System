using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public int RestaurantId { get; set;}
        [ForeignKey(nameof(RestaurantId)) ]
        public Restaurant? Restaurant { get; set; }
    }
}
