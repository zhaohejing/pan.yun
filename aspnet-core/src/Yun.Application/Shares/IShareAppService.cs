using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using YT.Shares.Dtos;
using Yun.Shares.Dtos;

namespace Yun.Shares
{
    public interface IShareAppService : IApplicationService
    {
        #region 分享管理

        /// <summary>
        /// 根据查询条件获取分享分页列表
        /// </summary>
        Task<PagedResultDto<ShareListDto>> GetPagedSharesAsync(GetShareInput input);

        /// <summary>
        /// 新增或更改分享
        /// </summary>
        Task CreateOrUpdateShareAsync(CreateOrUpdateShareInput input);

        /// <summary>
        /// 删除分享
        /// </summary>
        Task DeleteShareAsync(EntityDto<int> input);

        /// <summary>
        /// 评论分享
        /// </summary>
        Task CommentShare(CommentInput input);

        /// <summary>
        /// 批量删除分享
        /// </summary>
        Task BatchDeleteShareAsync(List<int> input);

        /// <summary>
        /// 获取分享详情带评论
        /// </summary>
        Task<ShareDetail> GetShareDetailAsync(EntityDto<int> input);

        /// <summary>
        /// 获取分享详情
        /// </summary>
        Task<ShareListDto> GetShareByIdAsync(EntityDto<int> input);

        #endregion 分享管理
    }
}