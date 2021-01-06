using System.Collections.Generic;

namespace StackOverflow.ViewModels.ViewModels
{
    public class DiscussionViewModel
    {
        public int Id { get; set; }

        public string DiscussionTitle { get; set; }
        public string DiscussionText { get; set; }
        public int Views { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public UserViewModel User { get; set; }
        public CategoryViewModel Category { get; set; }
        public virtual List<CommentViewModel> Comments { get; set; }
    }
}
