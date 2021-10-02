using AutoMapper;
using Contacts.DTOs.Concrete;
using Contacts.Entities.Concrete;

namespace Contacts.BusinessLogic.MapperProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
