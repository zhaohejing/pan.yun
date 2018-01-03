using System.ComponentModel;
using Abp.AutoMapper;

namespace Yun.Shares.Dtos
{
    /// <summary>
    /// 分享编辑dto
    /// </summary>
    [AutoMap(typeof(Share))]
    public class ShareEditDto
    {
        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

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
    }
}