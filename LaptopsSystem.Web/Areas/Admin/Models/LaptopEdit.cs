using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopsSystem.Web.Areas.Admin.Models
{
    public class LaptopEdit
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string MonitorSizeId { get; set; }

        [Required(ErrorMessage = "Hard disk size is required")]
        [Range(1, 10000, ErrorMessage = "Hard disk size should be between {1} and {2} GB")]
        [Display(Name="Hard disk")]
        public int? HardDisk { get; set; }

        [Required(ErrorMessage = "RAM size is required")]
        [Range(1, 128, ErrorMessage = "RAM size should be between {1} and {2} GB")]
        [Display(Name="RAM")]
        public int? Ram { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        [DataType(DataType.MultilineText)]
        [RegularExpression(@"^(http|https)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$", ErrorMessage = "URL is not valid")]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1.0, 10000.0, ErrorMessage = "{0} should be between £{1}.00 and £{2}.00")]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        [Range(0.3, 10.0, ErrorMessage = "{0} should be between {1} and {2} kg")]
        [DisplayFormat(ApplyFormatInEditMode = false, ConvertEmptyStringToNull = true)]
        public double? Weight { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        [Display(Name = "Additional parts")]
        [DataType(DataType.MultilineText)]
        public string AdditionalParts { get; set; }

        [StringLength(3000, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Description { get; set; }
    }
}