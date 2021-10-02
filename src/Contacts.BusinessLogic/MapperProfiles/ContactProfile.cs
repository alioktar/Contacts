using AutoMapper;
using Contacts.DTOs.Concrete;
using Contacts.Entities.Concrete;

namespace Contacts.BusinessLogic.MapperProfiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}
