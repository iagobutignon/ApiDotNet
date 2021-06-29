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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerModel> InsertAsync(CustomerRequest request)
        {
            var entity = _mapper.Map<CustomerEntity>(request);
            entity = await _customerRepository.InsertAsync(entity);
            return _mapper.Map<CustomerModel>(entity);
        }

        public async Task<CustomerModel> UpdateAsync(Guid id, CustomerRequest request)
        {
            var entity = await _customerRepository.GetByIdAsync(id);
            entity = await _customerRepository.UpdateAsync(entity);
            return _mapper.Map<CustomerModel>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _customerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerModel>> GetAsync(Expression<Func<CustomerEntity, bool>> predicate)
        {
            return _mapper.Map<IEnumerable<CustomerModel>>(await _customerRepository.GetAsync(predicate));
        }

        public async Task<CustomerModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<CustomerModel>(await _customerRepository.GetByIdAsync(id));
        }
    }
}