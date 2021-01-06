using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels.ViewModels
{
    public class NewDiscussionViewModel
    {
        [Required]
        [DisplayName("Discussion Title")]
        public string DiscussionTitle { get; set; }

        [Required]
        [DisplayName("Discussion Text")]
        public string DiscussionText { get; set; }
        
        [Required]
        public int Views { get; set; }
        
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
