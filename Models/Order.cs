using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        [ForeignKey(nameof(RestaurantId))]
        public Restaurant? Restaurant { get; set; } 
        public double Quantity { get; set; }
        [ForeignKey(nameof(MenuId))]
        public int MenuId { get; set; }

        [ForeignKey(nameof(UserId))]
        public string? UserId { get; set; }  

        public DateTimeOffset? OrderDate { get; set; } = DateTimeOffset.Now;
    }
}
