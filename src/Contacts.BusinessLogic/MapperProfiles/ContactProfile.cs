using AutoMapper;
using Contacts.DTOs;
using Contacts.Entities;

namespace Contacts.BusinessLogic.MapperProfiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();

            CreateMap<Contact, ContactAddDto>().ReverseMap();
            CreateMap<Contact, ContactAddWithPersonDto>().ReverseMap();
            
            CreateMap<Contact, ContactUpdateDto>().ReverseMap();
            CreateMap<Contact, ContactUpdateWithPersonDto>().ReverseMap();
        }
    }
}
