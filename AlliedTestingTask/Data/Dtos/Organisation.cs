using System;
using System.ComponentModel.DataAnnotations;

namespace AlliedTestingTask.Data.Models
{
    public class Organisation
    {
        [Required]
        [StringLength(120, ErrorMessage = "{0} length of address must be between {2} and {1}.", MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}