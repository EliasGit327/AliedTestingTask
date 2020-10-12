using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace AlliedTestingTask.Data.Models.Requests
{
    public class RegistrationRequest
    {
        [Required]
        [SwaggerSchema("The date when the person registered.")]
        public DateTime RegistrationDate { get; set; }
        [DefaultValue("en")]
        public string Locale { get; set; }
        [Required]
        public Person Person { get; set; }
        [Required]
        public Organisation Organisation { get; set; }
    }
}