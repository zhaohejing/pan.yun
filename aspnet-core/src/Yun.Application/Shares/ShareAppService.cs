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
    public class ShareAppService : YunAppServiceBase, IShareAppService
    {
        private readonly IRepository<Share> _shareRepository;
        private readonly IRepository<Comment> _commentRepository;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="shareRepository"></param>
        /// <param name="commentRepository"></param>
        public ShareAppService(IRepository<Share> shareRepository, IRepository<Comment> commentRepository)
        {
            _shareRepository = shareRepository;
            _commentRepository = commentRepository;
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
            var result = ObjectMapper.Map<List<ShareListDto>>(shares);
            return new PagedResultDto<ShareListDto>(count, result);
        }

        /// <summary>
        /// 获取分享详情带评论
        /// </summary>
        public async Task<ShareDetail> GetShareDetailAsync(EntityDto<int> input)
        {
            var entity = await _shareRepository.GetAsync(input.Id);
            return ObjectMapper.Map<ShareDetail>(entity);
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
        [AbpAuthorize]
        public async Task CreateOrUpdateShareAsync(CreateOrUpdateShareInput input)
        {
            if (input.ShareEditDto.Id.HasValue)
            {
                await UpdateShareAsync(input.ShareEditDto);
            }
            else
            {
                await CreateShareAsync(input.ShareEditDto);
            }
        }

        /// <summary>
        /// 评论分享
        /// </summary>
        [AbpAuthorize]
        public async Task CommentShare(CommentInput input)
        {
            var model = new Comment()
            {
                Content = input.Content,
                From = input.From.IsNullOrWhiteSpace() ? "游客" : input.From,
                FromImage = input.FromImage,
                ShareId = input.ShareId
            };
            await _commentRepository.InsertAsync(model);
        }

        /// <summary>
        /// 新增分享
        /// </summary>
        protected virtual async Task<ShareEditDto> CreateShareAsync(ShareEditDto input)
        {
            var entity = input.MapTo<Share>();
            entity = await _shareRepository.InsertAsync(entity);
            return entity.MapTo<ShareEditDto>();
        }

        /// <summary>
        /// 编辑分享
        /// </summary>
        protected virtual async Task UpdateShareAsync(ShareEditDto input)
        {
            var entity = await _shareRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);
            await _shareRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除分享
        /// </summary>
        [AbpAuthorize]

        public async Task DeleteShareAsync(EntityDto<int> input)
        {
            await _shareRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除分享
        /// </summary>
        [AbpAuthorize]

        public async Task BatchDeleteShareAsync(List<int> input)
        {
            await _shareRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion 分享管理
    }
}