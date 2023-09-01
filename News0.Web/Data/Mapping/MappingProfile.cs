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

            //CreateMap<Models.CategoryCreationViewModel, Domain.Dtos.CategoryDto>()
            //    .ForMember(dest => dest.CategoryTranslationDtos, opt => opt.MapFrom(src => src.Languages.ToList().Select((x, i) => new { item = x, index = i}).ToList().Select(l => new Domain.Dtos.CategoryTranslationDto() { Language = l.item.Text, Name = src.LanguagesNames[l.index] })));

            CreateMap<Domain.Dtos.CategoryTranslationDto, Models.CategoryTranslationViewModel>();
            CreateMap<Models.CategoryTranslationViewModel, Domain.Dtos.CategoryTranslationDto>();

            CreateMap<Domain.Dtos.PostTranslationDto, Models.Post.PostTranslationCreationViewModel>();
            CreateMap<Models.Post.PostTranslationCreationViewModel, Domain.Dtos.PostTranslationDto>();

            CreateMap<Domain.Dtos.PostDto, Models.Post.PostEditionViewModel>();
            CreateMap<Models.Post.PostEditionViewModel, Domain.Dtos.PostDto>();

            CreateMap<Models.Post.PostEditionViewModel, Domain.Dtos.PostTranslationDto>();
        }
    }
}
