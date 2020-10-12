using System;

namespace AlliedTestingTask.Data.Models.Responses
{
    public class GetRegistrationResponse
    {
        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Locale { get; set; }
        public Person Person { get; set; }
        public Organisation Organisation { get; set; }
    }
}