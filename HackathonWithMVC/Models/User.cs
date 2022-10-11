using System.ComponentModel.DataAnnotations;

namespace HackathonWithMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]     
        public string UserName { get; set; }
        [Required]     
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$", ErrorMessage = "Enter Valid Password")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$", ErrorMessage = "Please enter the correct email")]
        public string Email { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool IsBlocked { get; set; }

        
    }
}
