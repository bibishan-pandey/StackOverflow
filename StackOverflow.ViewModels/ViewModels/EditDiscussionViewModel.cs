using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels.ViewModels
{
    public class EditDiscussionViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Discussion Title")]
        public string DiscussionTitle { get; set; }

        [Required]
        [DisplayName("Discussion Text")]
        public string DiscussionText { get; set; }

        [Required]
        [DisplayName("User")]
        public int UserId { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
    }
}
