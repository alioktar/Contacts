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

        [HttpGet]
        public async Task<IDataResponse<ContactDto>> GetById(Guid id)
        {
            return await _contactService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<IDataResponse<IList<ContactDto>>> GetAll()
        {
            return await _contactService.GetAllAsync();
        }

        [HttpGet]
        public async Task<IDataResponse<IList<ContactDto>>> GetContactsByPersonId(Guid id)
        {
            return await _contactService.GetContactsByPersonIdAsync(id);
        }

        [HttpGet]
        public async Task<IList<LocationReportDto>> GetLocationReport()
        {
            return await _contactService.GetLocationReport();
        }

        [HttpPost]
        public async Task<IResponse> Add(ContactAddDto contact)
        {
            return await _contactService.AddAsync(contact);
        }

        [HttpPost]
        public async Task<IResponse> Update(ContactUpdateDto contact)
        {
            return await _contactService.UpdateAsync(contact);
        }

        [HttpPost]
        public async Task<IResponse> UpdateAll(List<ContactUpdateDto> contacts)
        {
            return await _contactService.UpdateRangeAsync(contacts);
        }

        [HttpPost]
        public async Task<IResponse> Delete(Guid id)
        {
            return await _contactService.DeleteAsync(id);
        }
    }
}
