using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using YT.Shares.Dtos;
using Yun.Authorization;
using Yun.Shares.Dtos;

namespace Yun.Shares
{
    /// <summary>
    /// 分享service
    /// </summary>
    [AbpAuthorize(PermissionNames.Pages_Shares)]
    public class ShareAppService : YunAppServiceBase, IShareAppService
    {
        private readonly IRepository<Share> _shareRepository;

        public ShareAppService(IRepository<Share> shareRepository)
        {
            _shareRepository = shareRepository;
        }

        #region 实体的自定义扩展方法

        private IQueryable<Share> ShareRepositoryAsNoTrack => _shareRepository.GetAll().AsNoTracking();

        #endregion 实体的自定义扩展方法

        #region 分享管理

        /// <summary>
        /// 根据查询条件获取分享分页列表
        /// </summary>
        public async Task<PagedResultDto<ShareListDto>> GetPagedSharesAsync(GetShareInput input)
        {
            var query = ShareRepositoryAsNoTrack;
            query = query.WhereIf(!input.Filter.IsNullOrWhiteSpace(), c => c.Title.Contains(input.Filter));
            var count = await query.CountAsync();
            var shares = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();
            var result = shares.MapTo<List<ShareListDto>>();
            return new PagedResultDto<ShareListDto>(count, result);
        }

        /// <summary>
        /// 获取分享详情
        /// </summary>
        public async Task<ShareListDto> GetShareByIdAsync(EntityDto<int> input)
        {
            var entity = await _shareRepository.GetAsync(input.Id);

            return entity.MapTo<ShareListDto>();
        }

        /// <summary>
        /// 新增或更改分享
        /// </summary>
        public async Task CreateOrUpdateSchedulingAsync(CreateOrUpdateShareInput input)
        {
            if (input.ShareEditDto.Id.HasValue)
            {
                await UpdateSchedulingAsync(input.ShareEditDto);
            }
            else
            {
                await CreateSchedulingAsync(input.ShareEditDto);
            }
        }

        /// <summary>
        /// 新增分享
        /// </summary>
        protected virtual async Task<ShareEditDto> CreateSchedulingAsync(ShareEditDto input)
        {
            var entity = input.MapTo<Share>();
            entity = await _shareRepository.InsertAsync(entity);
            return entity.MapTo<ShareEditDto>();
        }

        /// <summary>
        /// 编辑分享
        /// </summary>
        protected virtual async Task UpdateSchedulingAsync(ShareEditDto input)
        {
            var entity = await _shareRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);
            await _shareRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除分享
        /// </summary>
        public async Task DeleteSchedulingAsync(EntityDto<int> input)
        {
            await _shareRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除分享
        /// </summary>
        public async Task BatchDeleteSchedulingAsync(List<int> input)
        {
            await _shareRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion 分享管理
    }
}