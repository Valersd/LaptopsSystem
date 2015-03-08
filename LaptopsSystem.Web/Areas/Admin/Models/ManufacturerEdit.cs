using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaptopsSystem.Web.Areas.Admin.Models
{
    public class ManufacturerEdit : ManufacturerInput
    {
        public int Id { get; set; }
    }
}