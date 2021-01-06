using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels.ViewModels
{
    public class NewCommentViewModel
    {
        [Required]
        [DisplayName("Comment")]
        public string CommentText { get; set; }

        [Required]
        [DisplayName("User")]
        public int UserId { get; set; }

        [Required]
        [DisplayName("Discussion")]
        public int DiscussionId { get; set; }
    }
}
