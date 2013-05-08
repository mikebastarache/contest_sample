using System.ComponentModel.DataAnnotations;

namespace mm_contest.ViewModels
{
    public class InviteViewModel
    {
        [Required]
        [MaxLength(50)]
        public string InviteFirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string InviteLastName { get; set; }

        [Required]
        [RegularExpression(@"^[^,<>\s@]+@([^\s,@\.\[\]]+\.)*[^\s,@\.\[\]]+\.[^\s,@\.\[\]]+$")]
        [MaxLength(150)]
        public string InviteEmail { get; set; }
    }
}