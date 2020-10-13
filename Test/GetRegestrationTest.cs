using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AlliedTestingTask;
using AlliedTestingTask.Data.Models.Requests;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    public class GetRegestrationTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly HttpClient _client;

        public GetRegestrationTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task GetRegistrationTest()
        {
            var response = await _client.GetAsync("https://localhost:5001/api/v1/registrations");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}