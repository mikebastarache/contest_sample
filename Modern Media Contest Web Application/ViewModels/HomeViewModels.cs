using mm_contest.Classes;
using System.ComponentModel.DataAnnotations;

namespace mm_contest.ViewModels
{
    public class VerifyUserViewModel
    {
        [Required(ErrorMessage = "Error message here.")]
        [RegularExpression(@"^[^,<>\s@]+@([^\s,@\.\[\]]+\.)*[^\s,@\.\[\]]+\.[^\s,@\.\[\]]+$", ErrorMessage = "Invalid Email")]
        [MaxLength(255)]
        public string Email { get; set; }

        [EnforceTrue(ErrorMessage = "Checkbox Error Message")]
        public bool AcceptRules { get; set; }
    }
}