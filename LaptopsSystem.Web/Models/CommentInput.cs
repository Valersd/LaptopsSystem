using System.ComponentModel.DataAnnotations;

namespace LaptopsSystem.Web.Models
{
    public class CommentInput
    {
        public int LaptopId { get; set; }

        [Required(ErrorMessage = "Comment cannot be empty")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Comment must be between {2} and {1} characters")]
        [Display(Name = "Add Comment")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}