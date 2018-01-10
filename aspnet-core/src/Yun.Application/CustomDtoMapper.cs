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
using Yun.Authorization.Accounts.Dto;
using Yun.Authorization.Permissions.Dto;
using Yun.Authorization.Roles;
using Yun.Authorization.Roles.Dto;
using Yun.Authorization.Users;
using Yun.Authorization.Users.Dto;
using Yun.Friendships;
using Yun.Friendships.Dto;
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

          

            //Chat

            //Feature

            //Role
            configuration.CreateMap<RoleEditDto, Role>().ReverseMap();
            configuration.CreateMap<Role, RoleListDto>();
            configuration.CreateMap<UserRole, UserListRoleDto>();

            //friends
            configuration.CreateMap<FriendDto, Friendship>();
            //Permission
            configuration.CreateMap<Permission, FlatPermissionDto>();
            configuration.CreateMap<Permission, FlatPermissionWithLevelDto>();

         

            //Tenant
            configuration.CreateMap<Tenant, TenantLoginInfoDto>();
            configuration.CreateMap<CurrentTenantInfoDto, Tenant>().ReverseMap();

            //User
            configuration.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());
            configuration.CreateMap<User, UserLoginInfoDto>();
            configuration.CreateMap<User, UserListDto>();
            configuration.CreateMap<UserLoginAttemptDto, UserLoginAttempt>().ReverseMap();

            //AuditLog

            //Friendship

            //OrganizationUnit

            //Inputs
            configuration.CreateMap<Share, ShareListDto>()
                .ForMember(c => c.CategoryName, opt => opt.MapFrom(c => c.Category.CateName));
            configuration.CreateMap<Share, ShareDetail>()
                .ForMember(c => c.CategoryName, opt => opt.MapFrom(c => c.Category.CateName));
        }
    }
}
