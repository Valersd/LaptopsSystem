using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopsSystem.Models
{
    public class Manufacturer
    {
        private readonly ICollection<Laptop> _laptops;

        public Manufacturer()
        {
            _laptops = new HashSet<Laptop>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40,MinimumLength=2)]
        [Index(IsUnique=true)]
        public string Name { get; set; }

        public virtual ICollection<Laptop> Laptops { get; set; }
    }
}
