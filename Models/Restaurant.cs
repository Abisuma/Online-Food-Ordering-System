﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Address { get; set; } 
        public string PhoneNumber { get; set; }
        [Required]
        [WebsiteUrlValidation]
        public string Website { get; set; }  
        
        public List<Menu> Menu { get; set; }
    }
}