using Contacts.BusinessLogic.Services.Abstract;
using Contacts.Core.Response.Abstract;
using Contacts.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.HttpApi.Person
{
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("getById")]
        public async Task<IDataResponse<PersonDto>> GetById(Guid id)
        {
            return await _personService.GetByIdAsync(id);
        }

        [HttpGet("getAll")]
        public async Task<IDataResponse<IList<PersonDto>>> GetAll()
        {
            return await _personService.GetAllAsync();
        }
    }
}
