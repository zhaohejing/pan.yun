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
        /// 分类名
        /// </summary>

        public string CategoryName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }

    /// <summary>
    /// 巡检日志列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Share))]
    public class ShareDetail : EntityDto<int>
    {
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadImage { get; set; }
        /// <summary>
        /// 标题
        /// </summary>

        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 分类名
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        public virtual List<CommentDto> Comments { get; set; }
    }

    [AutoMapFrom(typeof(Comment))]
    public class CommentDto : EntityDto
    {
        public int ShareId { get; set; }

        /// <summary>
        /// 评论人
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 评论人头像
        /// </summary>
        public string FromImage { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}