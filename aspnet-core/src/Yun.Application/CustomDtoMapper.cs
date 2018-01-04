using AutoMapper;
using Yun.Shares;
using Yun.Shares.Dtos;

namespace Yun
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //Inputs
            configuration.CreateMap<Share, ShareListDto>()
                .ForMember(c => c.CategoryName, opt => opt.MapFrom(c => c.Category.CateName));
            configuration.CreateMap<Share, ShareDetail>()
                .ForMember(c => c.CategoryName, opt => opt.MapFrom(c => c.Category.CateName));
        }
    }
}
