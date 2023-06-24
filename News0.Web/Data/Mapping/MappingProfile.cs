using AutoMapper;

namespace News0.Web.Data.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Dtos.NewsDto, Models.NewsViewModel>();
        }
    }
}
