using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yun.Storage
{
    /// <summary>
    /// 文件存储
    /// </summary>
    [Table("sys_objectstorage")]
    public sealed class BinaryObject : Entity<Guid>
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        [Required]
        public string Url { get; set; }
        /// <summary>
        /// 文件尺寸
        /// </summary>
        public long? Size { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 后缀名
        /// </summary>
        public string Suffix { get; set; }


        public BinaryObject()
        {
            Id = Guid.NewGuid();
        }

        public BinaryObject(Guid id, string url)
        {
            Id = id;
            Url = url;
        }

        public BinaryObject(string url)
            : this()
        {
            Url = url;
        }
    }
}
