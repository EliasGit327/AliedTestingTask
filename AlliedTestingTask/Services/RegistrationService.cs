using System;
using System.Collections.Generic;
using System.Linq;
using AlliedTestingTask.Data.Models;

namespace AlliedTestingTask.Services
{
    public class RegistrationService
    {
        private readonly List<Registration> _registrations = new List<Registration>();

        public RegistrationService()
        {
            GenerateRegistration();
        }
        
        public List<Registration> GetAll()
        {
            return _registrations;
        }

        public Registration GetById(string id)
        {
            return _registrations.FirstOrDefault(r => r.Id == new Guid(id));
        }

        public Guid Add(Registration registration)
        {
            registration.Id = Guid.NewGuid();
            _registrations.Add(registration);
            return registration.Id;
        }

        private void GenerateRegistration()
        {
            var valve = new Organisation()
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

            var gabeNewel = new Person()
            {
                FirstName = "Gabe",
                LastName = "Newel",
                Email = "gaben@valvesoftware.com",
                Address = new Address()
                {
                    Locale = "en",
                    AddressLine1 = "San Francisco, M1257"
                }
        };
            
            _registrations.Add(new Registration()
            {
                Id = new Guid("569839dd-9668-4872-b829-1d6c1787c6c6"),
                RegistrationDate = Convert.ToDateTime("2020-05-21T23:11:46.616597+03:00"),
                Locale = "en",
                Organisation = valve,
                Person = gabeNewel
            });
        }
    }
}
