﻿using Contacts.BusinessLogic.Services.Abstract;
using Contacts.Core.Response.Abstract;
using Contacts.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.HttpApi
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

        [HttpPost("add")]
        public async Task<IResponse> Add(PersonAddDto person)
        {
            return await _personService.AddAsync(person);
        }

        [HttpPost("update")]
        public async Task<IResponse> Update(PersonUpdateDto person)
        {
            return await _personService.UpdateAsync(person);
        }

        [HttpPost("delete")]
        public async Task<IResponse> Delete(Guid id)
        {
            return await _personService.DeleteAsync(id);
        }
    }
}
