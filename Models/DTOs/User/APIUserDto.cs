using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.User
{
    public class APIUserDto : LoginDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
    }
}
