using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Db.Entities;
using Api.Interfaces.Repositories;
using Api.Interfaces.Services;
using Api.Models;
using Api.Models.Requests;
using AutoMapper;

namespace Api.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<AddressModel> InsertAsync(AddressRequest request)
        {
            var entity = _mapper.Map<AddressEntity>(request);
            entity = await _addressRepository.InsertAsync(entity);
            return _mapper.Map<AddressModel>(entity);
        }

        public async Task<AddressModel> UpdateAsync(Guid id, AddressRequest request)
        {
            var entity = await _addressRepository.GetByIdAsync(id);
            entity = await _addressRepository.UpdateAsync(entity);
            return _mapper.Map<AddressModel>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _addressRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AddressModel>> GetAsync(Expression<Func<AddressEntity, bool>> predicate)
        {
            return _mapper.Map<IEnumerable<AddressModel>>(await _addressRepository.GetAsync(predicate));
        }

        public async Task<AddressModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<AddressModel>(await _addressRepository.GetByIdAsync(id));
        }
    }
}