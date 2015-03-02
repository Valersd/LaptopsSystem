using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopsSystem.Models
{
    public class Vote
    {
        [Key]
        [Column(Order=0)]
        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }

        [Key]
        [Column(Order=1)]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
