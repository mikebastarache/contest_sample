using System;
using mm_contest.Classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mm_contest.ViewModels
{
    public class LegalAgeViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Province { get; set; }

        [Required]
        [MaxLength(4)]
        public int DobYear { get; set; }

        [Required]
        [MaxLength(2)]
        public int DobMonth { get; set; }

        [Required]
        [MaxLength(2)]
        public int DobDay { get; set; }

        public DateTime? Dob { get; set; }
    }
}