using Contacts.BusinessLogic.Services.Abstract;
using Contacts.Core.Response.Abstract;
using Contacts.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.HttpApi
{
    public class ContactsController : BaseController
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService personService)
        {
            _contactService = personService;
        }

        [HttpGet("getById")]
        public async Task<IDataResponse<ContactDto>> GetById(Guid id)
        {
            return await _contactService.GetByIdAsync(id);
        }

        [HttpGet("getAll")]
        public async Task<IDataResponse<IList<ContactDto>>> GetAll()
        {
            return await _contactService.GetAllAsync();
        }

        [HttpGet("getByPersonId")]
        public async Task<IDataResponse<IList<ContactDto>>> GetAll(Guid id)
        {
            return await _contactService.GetByPersonIdAsync(id);
        }

        [HttpPost("add")]
        public async Task<IResponse> Add(ContactAddDto contact)
        {
            return await _contactService.AddAsync(contact);
        }

        [HttpPost("update")]
        public async Task<IResponse> Update(ContactUpdateDto contact)
        {
            return await _contactService.UpdateAsync(contact);
        }

        [HttpPost("updateAll")]
        public async Task<IResponse> UpdateAll(List<ContactUpdateDto> contacts)
        {
            return await _contactService.UpdateRangeAsync(contacts);
        }

        [HttpPost("delete")]
        public async Task<IResponse> Delete(Guid id)
        {
            return await _contactService.DeleteAsync(id);
        }
    }
}
