using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Yun.Categorys.Dtos;

namespace Yun.Categorys
{
    public interface ICategoryAppService : IApplicationService
    {
        #region 分类管理

        /// <summary>
        /// 根据查询条件获取分类分页列表
        /// </summary>
        Task<PagedResultDto<CategoryListDto>> GetPagedCategorysAsync(GetCategoryInput input);

        /// <summary>
        /// 获取分类详情
        /// </summary>
        Task<CategoryListDto> GetCategoryByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 新增或更改分类
        /// </summary>
        Task CreateOrUpdateCategoryAsync(CreateCategoryInput input);

        /// <summary>
        /// 删除分类
        /// </summary>
        Task DeleteCategoryAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除分类
        /// </summary>
        Task BatchDeleteCategoryAsync(List<int> input);

        #endregion 分类管理
    }
}