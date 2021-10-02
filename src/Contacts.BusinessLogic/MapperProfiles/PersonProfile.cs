using AutoMapper;
using Contacts.DTOs.Concrete;
using Contacts.Entities.Concrete;

namespace Contacts.BusinessLogic.MapperProfiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }
    }
}
