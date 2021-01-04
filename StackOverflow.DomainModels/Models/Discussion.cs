using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflow.DomainModels.Models
{
    public class Discussion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string DiscussionTitle { get; set; }
        public string DiscussionText { get; set; }
        public int Views { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int UserId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual List<Vote> Votes { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
