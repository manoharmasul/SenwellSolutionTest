using System.ComponentModel.DataAnnotations;

namespace SenwellSolutionTest.Model
{


    public class Employee
    {
        [Required(ErrorMessage = "Please enter username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*\W)[A-Za-z\d\W]{8,}$", ErrorMessage = "Invalid password format. It must contain at least one uppercase letter, one lowercase letter, and one special character.")]
        public string password { get; set; }
    }

}
