using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Yun.Shares;

namespace Yun.Categorys.Dtos
{
    /// <summary>
    /// 巡检日志列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Category))]
    public class CategoryListDto : EntityDto<int>
    {
        /// <summary>
        /// 标题
        /// </summary>

        public string CateName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}