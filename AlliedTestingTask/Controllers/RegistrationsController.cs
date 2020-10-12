using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlliedTestingTask.Data.Models;
using AlliedTestingTask.Data.Models.Requests;
using AlliedTestingTask.Data.Models.Responses;
using AlliedTestingTask.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlliedTestingTask.Controllers
{
    [ApiController]
    [Route("api/v1/registrations")]
    public class RegistrationsController : ControllerBase
    {
        private OrganisationService _organisationService;
        private RegistrationService _registrationService;
        private IMapper _mapper;

        public RegistrationsController
        (
            OrganisationService organisationService,
            RegistrationService registrationService,
            IMapper mapper
        )
        {
            _organisationService = organisationService;
            _registrationService = registrationService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<GetRegistrationResponse>> GetAll()
        {
            return _registrationService.GetAll()
                .Select(r => _mapper.Map<GetRegistrationResponse>(r)).ToList();
            
        }

        [HttpGet("{registrationId}")]
        public ActionResult<GetRegistrationResponse> Get
            ([FromHeader] string? xCorrelationid, string registrationId = "x-569839dd-9668-4872-b829-1d6c1787c6c6")
        {
            return Ok(new GetRegistrationResponse());
        }

        [HttpPost]
        public ActionResult<RegistrationResponse> Post([FromBody] RegistrationRequest registrationRequest)
        {
            return Ok
            (
                new RegistrationResponse()
                {
                    RegistrationId = "42"
                }
            );
        }
    }
}