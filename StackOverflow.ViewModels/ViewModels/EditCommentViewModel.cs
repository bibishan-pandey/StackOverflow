using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels.ViewModels
{
    public class EditCommentViewModel
    {
        [Required]
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

        public DiscussionViewModel Discussion { get; set; }
    }
}
