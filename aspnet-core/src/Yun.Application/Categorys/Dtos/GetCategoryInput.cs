using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace Yun.Categorys.Dtos
{
    /// <summary>
    /// 巡检日志查询Dto
    /// </summary>
    public class GetCategoryInput : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 模糊查询参数
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// 用于排序的默认值
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "CreationTime desc";
            }
        }
    }
}