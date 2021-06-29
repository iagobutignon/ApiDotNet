using Api.Db.Entities;
using Api.Models;
using AutoMapper;

namespace Api.Mappings
{
    public class AutoMapperEntityToModelProfile : Profile
    {
        public AutoMapperEntityToModelProfile()
        {
            CreateMap<UserEntity, UserModel>();
            CreateMap<CustomerEntity, CustomerModel>();
        }
    }
}