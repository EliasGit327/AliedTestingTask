using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AlliedTestingTask.Data.Models
{
    public class Person
    {
        [Required]
        [StringLength(150, ErrorMessage = "{0} length of first name must be between {2} and {1}.", MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "{0} length of last name must be between {2} and {1}.", MinimumLength = 1)]
        public string LastName { get; set; }
        [Required]
        [StringLength(254, ErrorMessage = "{0} length of email must be between {2} and {1}.", MinimumLength = 1)]
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}