using System.Collections.Generic;
using AlliedTestingTask.Data.Models;
using AlliedTestingTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlliedTestingTask.Controllers
{
    [ApiController]
    [Route("api/v1/organisations")]
    public class OrganisationController : ControllerBase
    {
        private OrganisationService _organisationService;
        
        public OrganisationController(OrganisationService organisationService)
        {
            _organisationService = organisationService;
        }
        
        [HttpGet]
        public ActionResult<List<Organisation>> GetAll()
        {
            return Ok(_organisationService.GetAll());
        }
    }
}