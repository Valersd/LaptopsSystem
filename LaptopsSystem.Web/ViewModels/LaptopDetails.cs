using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using LaptopsSystem.Models;
using LaptopsSystem.Web.Areas.Admin.Models;

namespace LaptopsSystem.Web.ViewModels
{
    public class LaptopDetails : LaptopAdminIndex
    {
        [DisplayFormat(DataFormatString="{0} kg")]
        public double? Weight { get; set; }

        [Display(Name="Additional parts")]
        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        [Display(Name="Votes")]
        public int VotesCount { get; set; }

        [Display(Name="Image")]
        public override string ImageUrl { get; set; }
        

        public bool HasVoted { get; set; }

        public IList<CommentInLaptop> Comments { get; set; }


    }
}