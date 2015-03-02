using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaptopsSystem.Models
{
    public class Laptop
    {
        private readonly ICollection<Vote> _votes;
        private readonly ICollection<Commment> _comments;

        public Laptop()
        {
            _votes = new HashSet<Vote>();
            _comments = new HashSet<Commment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30,MinimumLength=3)]
        public string Model { get; set; }


        [Required]
        [Range(1,10000)]
        public int HardDisk { get; set; }

        [Required]
        [Range(1,128)]
        public int Ram { get; set; }

        [Required]
        [StringLength(200,MinimumLength=5)]
        public string ImageUrl { get; set; }

        [Range(0.3,10.0)]
        public double? Weight { get; set; }

        [StringLength(200,MinimumLength=3)]
        public string AdditionalParts { get; set; }

        [StringLength(1000,MinimumLength=3)]
        public string Description { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public int MonitorId { get; set; }

        public virtual MonitorSize Monitor { get; set; }

        public ICollection<Vote> Votes { get; set; }

        public ICollection<Commment> Comments { get; set; }


    }
}
