using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Yun.Categorys.Dtos;
using Yun.Shares;

namespace Yun.Categorys
{
    /// <summary>
    /// 分类service
    /// </summary>
    [AbpAuthorize]
    public class CategoryAppService : YunAppServiceBase, ICategoryAppService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryAppService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #region 实体的自定义扩展方法

        private IQueryable<Category> CategoryRepositoryAsNoTrack => _categoryRepository.GetAll().AsNoTracking();

        #endregion 实体的自定义扩展方法

        #region 分类管理

        /// <summary>
        /// 根据查询条件获取分类分页列表
        /// </summary>
        public async Task<PagedResultDto<CategoryListDto>> GetPagedCategorysAsync(GetCategoryInput input)
        {
            var query = CategoryRepositoryAsNoTrack;
            query = query.WhereIf(!input.Filter.IsNullOrWhiteSpace(), c => c.CateName.Contains(input.Filter));
            var count = await query.CountAsync();
            var cates = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();
            var result = cates.MapTo<List<CategoryListDto>>();
            return new PagedResultDto<CategoryListDto>(count, result);
        }

        /// <summary>
        /// 获取分类详情
        /// </summary>
        public async Task<CategoryListDto> GetCategoryByIdAsync(EntityDto<int> input)
        {
            var entity = await _categoryRepository.GetAsync(input.Id);

            return entity.MapTo<CategoryListDto>();
        }

        /// <summary>
        /// 新增或更改分类
        /// </summary>
        public async Task CreateOrUpdateCategoryAsync(CreateCategoryInput input)
        {
            if (input.CategoryEditDto.Id.HasValue)
            {
                await UpdateCategoryAsync(input.CategoryEditDto);
            }
            else
            {
                await CreateCategoryAsync(input.CategoryEditDto);
            }
        }

        /// <summary>
        /// 新增分类
        /// </summary>
        protected virtual async Task<CategoryEditDto> CreateCategoryAsync(CategoryEditDto input)
        {
            var entity = input.MapTo<Category>();
            entity = await _categoryRepository.InsertAsync(entity);
            return entity.MapTo<CategoryEditDto>();
        }

        /// <summary>
        /// 编辑分类
        /// </summary>
        protected virtual async Task UpdateCategoryAsync(CategoryEditDto input)
        {
            var entity = await _categoryRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);
            await _categoryRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        public async Task DeleteCategoryAsync(EntityDto<int> input)
        {
            await _categoryRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除分类
        /// </summary>
        public async Task BatchDeleteCategoryAsync(List<int> input)
        {
            await _categoryRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion 分类管理
    }
}