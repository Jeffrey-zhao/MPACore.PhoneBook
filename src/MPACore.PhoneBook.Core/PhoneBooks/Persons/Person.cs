using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MPACore.PhoneBook.PhoneBooks.Persons
{
    /// <summary>
    /// 人员
    /// </summary>
    public class Person : FullAuditedEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(PhoneBookConsts.MaxNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [EmailAddress]
        [MaxLength(PhoneBookConsts.MaxEmailLength)]
        public string Email { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(PhoneBookConsts.MaxAddressLength)]
        public string Address { get; set; }
    }
}
