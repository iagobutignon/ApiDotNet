using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Mappings
{
    public static class AutoMapper
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperEntityToModelProfile());
                mc.AddProfile(new AutoMapperModelToEntityProfile());
            });
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(RegisterMappings().CreateMapper());
            services.AddSingleton<IMapper>(sp =>
                new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
        }
    }
}