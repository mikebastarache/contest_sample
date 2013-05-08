using mm_contest.Classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mm_contest.ViewModels
{
    public class VoteViewModel
    {
        [Required]
        [MaxLength(50)]
        public string voteValue { get; set; }

    }
}