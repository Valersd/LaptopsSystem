using LaptopsSystem.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopsSystem.Web.Areas.Admin.Models
{
    public class LaptopAdminIndex : LaptopIndex
    {
        [UIHint("_CutLongWords")]
        //[AdditionalMetadata("Length", 30)]
        public override string ImageUrl { get; set; }

        [Display(Name = "Hard disk")]
        [DisplayFormat(DataFormatString = "{0} GB")]
        public int HardDisk { get; set; }

        [Display(Name = "RAM")]
        [DisplayFormat(DataFormatString = "{0} GB")]
        public int Ram { get; set; }

        [Display(Name = "Display size")]
        [DisplayFormat(DataFormatString = "{0}\"")]
        public double Monitor { get; set; }
    }
}