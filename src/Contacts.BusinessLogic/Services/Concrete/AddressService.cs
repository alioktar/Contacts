using AutoMapper;
using Contacts.BusinessLogic.Core;
using Contacts.BusinessLogic.Services.Abstract;
using Contacts.Core.Response.Abstract;
using Contacts.Core.Response.Concrete;
using Contacts.DataAccess.Abstract;
using Contacts.DTOs.Concrete;
using Contacts.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.BusinessLogic.Services.Concrete
{
    public class AddressService : BaseService, IAddressService
    {
        public AddressService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public AddressService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<IResponse> AddAsync(AddressDto entity)
        {
            await UnitOfWork.AddressRepository.AddAsync(Mapper.Map<Address>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse();
        }

        public async Task<IResponse> DeleteAsync(AddressDto entity)
        {
            UnitOfWork.AddressRepository.Delete(Mapper.Map<Address>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse();
        }

        public async Task<IDataResponse<List<AddressDto>>> GetAllAsync()
        {
            var list = await UnitOfWork.AddressRepository.GetListAsync();
            return new SuccessDataResponse<List<AddressDto>>(Mapper.Map<List<AddressDto>>(list));
        }

        public async Task<IDataResponse<AddressDto>> GetByIdAsync(Guid id)
        {
            var Address = await UnitOfWork.AddressRepository.GetAsync(p => p.Id == id);
            return new SuccessDataResponse<AddressDto>(Mapper.Map<AddressDto>(Address));
        }

        public async Task<IResponse> UpdateAsync(AddressDto entity)
        {
            UnitOfWork.AddressRepository.Delete(Mapper.Map<Address>(entity));
            await UnitOfWork.SaveChangesAsync();
            return new SuccessResponse();
        }
    }
}
