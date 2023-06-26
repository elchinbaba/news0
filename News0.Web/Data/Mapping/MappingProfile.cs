using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace News0.Web.Data.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Dtos.NewsDto, Models.NewsViewModel>();
            //CreateMap<Models.NewsViewModel, Domain.Dtos.NewsDto>();
            CreateMap<Models.NewsCreationViewModel, Domain.Dtos.NewsDto>()
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => new Domain.Entities.Language { Id = src.LanguageId }))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Domain.Entities.Category { Id = src.CategoryId }))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));
        }
    }
}
