using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace News0.Web.Data.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Dtos.PostDto, Models.Post.PostViewModel>();
            //CreateMap<Models.NewsViewModel, Domain.Dtos.NewsDto>();
            CreateMap<Models.Post.PostCreationViewModel, Domain.Dtos.PostDto>()
                .ForMember(dest => dest.Language, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));

            CreateMap<Domain.Dtos.LanguageDto, Models.LanguageViewModel>();
            CreateMap<Models.LanguageViewModel, Domain.Dtos.LanguageDto>();

            CreateMap<Domain.Dtos.CategoryDto, Models.CategoryViewModel>();
            CreateMap<Models.CategoryViewModel, Domain.Dtos.CategoryDto>();

            CreateMap<Models.CategoryCreationViewModel, Domain.Dtos.CategoryDto>();
        }
    }
}
