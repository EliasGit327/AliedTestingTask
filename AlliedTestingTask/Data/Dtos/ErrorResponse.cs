using System.Collections.Generic;

namespace AlliedTestingTask.Data.Models
{
    public class ErrorResponse
    {
        public Error Error { get; set; }
        public ICollection<FieldError> FieldErrors { get; set; }
    }
}