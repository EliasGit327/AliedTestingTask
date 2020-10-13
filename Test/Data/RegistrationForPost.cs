using System;
using AlliedTestingTask.Data.Models;
using AlliedTestingTask.Data.Models.Requests;

namespace Test
{
    public class RegistrationForPost
    {
        private static Organisation valve = new Organisation()
        {
            Name = "Valve",
            Address = new Address()
            {
                AddressLine1 = "Bellevue, Washington",
                CountryIsoCode = "3166-2",
                City = "San Francisco",
                State = "California",
                PostCode = "94016",
                Locale = "en"
            }
        };

        private static Person gabeNewel = new Person()
        {
            FirstName = "Gabe",
            LastName = "Newel",
            Email = "gaben@valvesoftware.com",
            Address = new Address()
            {
                Locale = "en",
                AddressLine1 = "San Francisco, M1257",
                CountryIsoCode = "A231321"
            },
        };
        
        public static RegistrationRequest RegistrationRequest = new RegistrationRequest()
        {
            RegistrationDate = DateTime.Now,
            Locale = "en",
            Organisation = valve,
            Person = gabeNewel
        };
    }
}