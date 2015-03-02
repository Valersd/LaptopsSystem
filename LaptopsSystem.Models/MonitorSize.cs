using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LaptopsSystem.Models
{
    public class MonitorSize
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1.0,100.0)]
        public double Size { get; set; }

        public virtual ICollection<Laptop> Laptops { get; set; }
    }
}
