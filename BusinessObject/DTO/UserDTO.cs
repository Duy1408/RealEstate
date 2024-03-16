using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "FullName is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        [RegularExpression(@"^(?=.*[0-9])[-0-9]{10,15}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public int RoleID { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Bid is required.")]
        public int BidID { get; set; }
    }
}
