using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.Examples;

namespace AlliedTestingTask.Data.Models
{
    public class Address
    {
        [StringLength(150, ErrorMessage = "{0} length of address must be between {2} and {1}.", MinimumLength = 1)]
        public string Locale { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "{0} length of address line 1 must be between {2} and {1}.", MinimumLength = 1)]
        public string AddressLine1 { get; set; }
        [StringLength(150, ErrorMessage = "{0} length of address line 2 must be between {2} and {1}.", MinimumLength = 1)]
        public string AddressLine2 { get; set; }
        [StringLength(150, ErrorMessage = "{0} length of address line 3 must be between {2} and {1}.", MinimumLength = 1)]
        public string AddressLine3 { get; set; }
        [MaxLength(40)]
        public string City { get; set; }
        [MaxLength(60)]                  
        public string State { get; set; }
        [MaxLength(60)]                  
        public string PostCode { get; set; }
        [Required]
        [SwaggerSchema("The ISO3 code of the country.")]
        public string CountryIsoCode { get; set; }
    }
}