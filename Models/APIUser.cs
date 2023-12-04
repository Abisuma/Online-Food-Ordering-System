﻿using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class APIUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
