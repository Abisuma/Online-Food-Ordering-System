using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Models.DTOs.Restaurant
{
    public class BaseRestaurantDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Phone]
        [StringLengthAttribute(11)]
        public string PhoneNumber { get; set; }
        [Required]
        [WebsiteUrlValidation]
        public string Website { get; set; }
        [Range(1,5, ErrorMessage ="Ratings are from 1 to 5")]
        public double? Rating { get; set; }

    }
}
