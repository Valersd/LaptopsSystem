using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LaptopsSystem.Web.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace LaptopsSystem.Web.Areas.Admin.Models
{
    public class CommentIndex : CommentInLaptop
    {
        public int LaptopId { get; set; }

        public string LaptopManufacturer { get; set; }

        public string LaptopModel { get; set; }
    }
}