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
        }
    }
}
