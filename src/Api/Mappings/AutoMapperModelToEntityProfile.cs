using Api.Db.Entities;
using Api.Models;
using Api.Models.Requests;
using AutoMapper;

namespace Api.Mappings
{
    public class AutoMapperModelToEntityProfile : Profile
    {
        public AutoMapperModelToEntityProfile()
        {
            CreateMap<UserRequest, UserEntity>();
            CreateMap<UserModel, UserEntity>();
            CreateMap<CustomerRequest, CustomerEntity>();
            CreateMap<CustomerModel, CustomerEntity>();
        }
    }
}