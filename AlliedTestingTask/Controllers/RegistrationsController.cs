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
        private RegistrationService _registrationService;
        private IMapper _mapper;

        public RegistrationsController
        (
            RegistrationService registrationService,
            IMapper mapper
        )
        {
            _registrationService = registrationService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Registration>> GetAll()
        {
            var result = _registrationService.GetAll()
                .Select(r => _mapper.Map<GetRegistrationResponse>(r)).ToList();
            
            return result.Count > 0 ? Ok(result) : BadRequest() as ActionResult;
        }

        [HttpGet("{registrationId}")]
        public ActionResult<GetRegistrationResponse> Get
            ([FromHeader] string? xCorrelationid, string registrationId = "569839dd-9668-4872-b829-1d6c1787c6c6")
        {
            var result = _registrationService.GetById(registrationId);
            
            return result != null ? Ok(result) : BadRequest() as ActionResult;
        }

        [HttpPost]
        public ActionResult<RegistrationResponse> Post([FromBody] RegistrationRequest registrationRequest)
        {
            var result = _registrationService.Add(_mapper.Map<Registration>(registrationRequest));

            return result != null ?
                Ok(new RegistrationResponse() { RegistrationId = result.ToString()}) : 
                BadRequest() as ActionResult;
        }
    }
}