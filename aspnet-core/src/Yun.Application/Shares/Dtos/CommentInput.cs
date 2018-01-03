using System;
using System.Collections.Generic;
using System.Text;

namespace Yun.Shares.Dtos
{
    /// <summary>
    /// 评论input
    /// </summary>
    public class CommentInput
    {
        /// <summary>
        /// 分享id
        /// </summary>
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
    }
}