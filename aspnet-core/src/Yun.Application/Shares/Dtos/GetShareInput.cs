using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace YT.Shares.Dtos
{
    /// <summary>
    /// 巡检日志查询Dto
    /// </summary>
    public class GetShareInput : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        /// <summary>
        /// 模糊查询参数
        /// </summary>
        public string Filter { get; set; }

        public int? Category { get; set; }
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