using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using LaptopsSystem.Models;

namespace LaptopsSystem.Web.ViewModels
{
    public class LaptopDetails : LaptopIndex
    {
        [Display(Name="Display size")]
        [DisplayFormat(DataFormatString="{0}\"")]
        public double Monitor { get; set; }

        [Display(Name="Hard disk")]
        [DisplayFormat(DataFormatString="{0} GB")]
        public int HardDisk { get; set; }

        [Display(Name="RAM")]
        [DisplayFormat(DataFormatString = "{0} GB")]
        public int Ram { get; set; }

        [DisplayFormat(DataFormatString="{0} kg")]
        public double? Weight { get; set; }

        [Display(Name="Additional parts")]
        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        [Display(Name="Votes")]
        public int VotesCount { get; set; }

        public bool HasVoted { get; set; }

        public IList<CommentInLaptop> Comments { get; set; }


    }
}