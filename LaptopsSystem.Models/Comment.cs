using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaptopsSystem.Models
{
    public class Comment
    {
        private DateTime _createdOn;

        public Comment()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1000, MinimumLength=3)]
        public string Content { get; set; }

        public DateTime CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }

        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
