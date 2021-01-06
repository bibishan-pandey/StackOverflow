using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}
