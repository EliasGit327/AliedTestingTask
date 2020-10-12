using AlliedTestingTask.Data.Models;
using AlliedTestingTask.Data.Models.Requests;
using AlliedTestingTask.Data.Models.Responses;
using AutoMapper;

namespace AlliedTestingTask.Data.MapperProfiles
{
    public class RegistrationMappingProfile: Profile
    {
        public RegistrationMappingProfile()
        {
            CreateMap<Registration, GetRegistrationResponse>();
            CreateMap<RegistrationRequest, Registration>();
        }
    }
}