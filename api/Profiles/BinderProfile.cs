using AutoMapper;

namespace api.Profiles
{
    public class BinderProfile : Profile
    {
        public BinderProfile()
        {
            CreateMap<Entities.Binder, Models.BinderDetailsDto>();
            CreateMap<Entities.Binder, Models.BinderDto>();
        }
    }
}
