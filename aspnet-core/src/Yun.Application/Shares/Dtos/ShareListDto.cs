using System;
using System.Collections.Generic;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Yun.Shares.Dtos
{
    /// <summary>
    /// 巡检日志列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Share))]
    public class ShareListDto : EntityDto<int>
    {
        /// <summary>
        /// 标题
        /// </summary>

        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 分类名
        /// </summary>

        public string CategoryName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}