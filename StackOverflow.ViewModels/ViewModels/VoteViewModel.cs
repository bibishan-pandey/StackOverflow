using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels.ViewModels
{
    public class VoteViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Vote Type")]
        public int VoteTypeId { get; set; }

        [Required]
        [DisplayName("User")]
        public int UserId { get; set; }

        [Required]
        [DisplayName("Discussion")]
        public int DiscussionId { get; set; }

        [DisplayName("Comment")]
        public int? CommentId { get; set; }

        public virtual VoteTypeViewModel VoteType { get; set; }
        public virtual UserViewModel User { get; set; }
        public virtual DiscussionViewModel Discussion { get; set; }
        public virtual CommentViewModel Comment { get; set; }
    }
}
