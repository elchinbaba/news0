using AutoMapper;

namespace News0.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.PostTranslation, Domain.Dtos.NewsDto>()
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language.Name));
        }
    }
}
