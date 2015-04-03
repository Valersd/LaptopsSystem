using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LaptopsSystem.Web.Areas.Admin.Models
{
    public class CommentEdit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Comment cannot be empty")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Comment should be between {2} and {1} symbols")]
        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Content { get; set; }

        public string LaptopManufacturer { get; set; }

        public string LaptopModel { get; set; }

        public string Author { get; set; }
    }
}