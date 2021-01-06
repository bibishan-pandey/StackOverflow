using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels.ViewModels
{
    public class VoteTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Vote { get; set; }
    }
}