﻿using AutoMapper;
using Contacts.DTOs;
using Contacts.Entities;

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
