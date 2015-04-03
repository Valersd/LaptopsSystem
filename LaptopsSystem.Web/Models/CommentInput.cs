using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LaptopsSystem.Web.Models
{
    public class CommentInput
    {
        public int LaptopId { get; set; }

        [Required(ErrorMessage = "Comment cannot be empty")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Comment should be between {2} and {1} symbols")]
        [Display(Name = "Add Comment")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Content { get; set; }
    }
}