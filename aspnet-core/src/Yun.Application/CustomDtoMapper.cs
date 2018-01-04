using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Localization;
using Abp.Notifications;
using Abp.Organizations;
using Abp.UI.Inputs;
using AutoMapper;
using Yun.Authorization.Roles;
using Yun.Authorization.Users;
using Yun.MultiTenancy;
using Yun.Sessions.Dto;
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

        }
    }
}
