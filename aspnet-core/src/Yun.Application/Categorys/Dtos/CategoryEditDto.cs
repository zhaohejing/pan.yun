using System.ComponentModel;
using Abp.AutoMapper;
using Yun.Shares;

namespace Yun.Categorys.Dtos
{
    /// <summary>
    /// 分享编辑dto
    /// </summary>
    [AutoMap(typeof(Category))]
    public class CategoryEditDto
    {
        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 分类名
        /// </summary>
        public string CateName { get; set; }
    }
}