using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaptopsSystem.Web.ViewModels
{
    public class LaptopIndex
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name="Image")]
        public virtual string ImageUrl { get; set; }
    }
}