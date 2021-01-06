using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Comment")]
        public string CommentText { get; set; }

        [Required]
        [DisplayName("User")]
        public int UserId { get; set; }

        [Required]
        [DisplayName("Discussion")]
        public int DiscussionId { get; set; }

        public int CurrentUserVoteType { get; set; }

        public virtual UserViewModel User { get; set; }

        public virtual List<VoteViewModel> Votes { get; set; }
    }
}
