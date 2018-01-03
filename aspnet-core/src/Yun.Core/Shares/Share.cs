using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yun.Shares
{
    /// <summary>
    /// 分享类型
    /// </summary>
    [Table("Share")]
    public class Share : CreationAuditedEntity, ISoftDelete
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required, MaxLength(120)]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [MaxLength(3000)]
        public string Content { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("ShareId")]
        public virtual ICollection<Comment> Comments { get; set; }
    }

    /// <summary>
    /// ping论内容同
    /// </summary>
    [Table("Comment")]
    public class Comment : CreationAuditedEntity, ISoftDelete
    {
        public int ShareId { get; set; }
        public virtual Share Share { get; set; }

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
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }

    /// <summary>
    /// 分类
    /// </summary>
    [Table("Category")]
    public class Category : CreationAuditedEntity, ISoftDelete
    {
        /// <summary>
        /// 分类名
        /// </summary>
        [Required, MaxLength(120)]
        public string CateName { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ICollection<Share> Shares { get; set; }
    }
}