using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaptopsSystem.Web.Areas.Admin.Models
{
    public class ManufacturerIndex
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name="Number of models")]
        public int LaptopModelsCount { get; set; }
    }
}