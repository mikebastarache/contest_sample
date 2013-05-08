using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using mm_contest.Classes;

namespace mm_contest.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public int? Salutation { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string Province { get; set; }

        [Required]
        [RegularExpression(@"[abceghjklmnprstvxyABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Za-z]{1} *\d{1}[A-Za-z]{1}\d{1}", ErrorMessage = "Invalid Postal Code")]
        [MaxLength(7)]
        public string PostalCode { get; set; }

        [Required]
        [RegularExpression(@"(1\s*[-\/\.]?)?(\((\d{3})\)|(\d{3}))\s*[-\/\.]?\s*(\d{3})\s*[-\/\.]?\s*(\d{4})\s*(([xX]|[eE][xX][tT])\.?\s*(\d+))*", ErrorMessage = "Invalid Phone")]
        [MaxLength(15)]
        public string Telephone { get; set; }

        [DisplayName("Language")]
        [MaxLength(255)]
        public string Language { get; set; }

        [DisplayName("Opt In")]
        public bool OptIn { get; set; }

        [Required]
        [MaxLength(50)]
        public string YearOfBirth { get; set; }

        public int OriginalFriendId { get; set; }

        public int ContestSignupId { get; set; }
    }
}

