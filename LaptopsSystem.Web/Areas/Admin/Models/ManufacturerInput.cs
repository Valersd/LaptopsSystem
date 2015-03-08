using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaptopsSystem.Web.Areas.Admin.Models
{
    public class ManufacturerInput
    {
        [Required(ErrorMessage="{0} is required")]
        [StringLength(40, MinimumLength = 2,ErrorMessage="{0} should be between {2} and {1} symbols")]
        public string Name { get; set; }
    }
}