using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DTOs
{
    public class UserSaved
    {
      
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Password must not have longer than 50 characters.")]
        public string Password { get; set; }

        [StringLength(50, ErrorMessage = "Hobbies must not have longer than 50 characters.")]
        public string Hobbies { get; set; }

        [StringLength(50, ErrorMessage = "FullName must not have longer than 50 characters.")]
        public string FullName { get; set; }

        [StringLength(50, ErrorMessage = "FullName must not have longer than 50 characters.")]
        public string PhoneNumber { get; set; }

        public string UserName { get; set; }
    }
}
