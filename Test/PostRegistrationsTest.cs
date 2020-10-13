using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AlliedTestingTask;
using AlliedTestingTask.Data.Models;
using AlliedTestingTask.Data.Models.Requests;
using FluentAssertions;
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
            var regReq = RegistrationForPost.RegistrationRequest;
            var parsedRegReq = await JsonConvert.SerializeObjectAsync(regReq);

            var response = await _client.PostAsync
            (
                "https://localhost:5001/api/v1/registrations",
                new StringContent(parsedRegReq, Encoding.UTF8, "application/json")
            );

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            _testOutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}