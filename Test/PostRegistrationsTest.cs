using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AlliedTestingTask;
using AlliedTestingTask.Data.Models;
using AlliedTestingTask.Data.Models.Requests;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    public class PostRegistrationsTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly HttpClient _client;

        public PostRegistrationsTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task PostRegistrationTest()
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
                    AddressLine1 = "San Francisco, M1257",
                    CountryIsoCode = "A231321"
                },
            };
            
            var regReq = new RegistrationRequest()
            {
                RegistrationDate = DateTime.Now,
                Locale = "en",
                Organisation = valve,
                Person = gabeNewel
            };
            var parsedRegReq = await JsonConvert.SerializeObjectAsync(regReq);

            var response = await _client.PostAsync
            (
                "https://localhost:5001/api/v1/registrations",
                new StringContent(parsedRegReq, Encoding.UTF8, "application/json")
            );
            
            if (!response.IsSuccessStatusCode)
            {
                _testOutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
                throw new InvalidOperationException("Bad request");
            }
            
            _testOutputHelper.WriteLine(parsedRegReq);

        }
    }
}