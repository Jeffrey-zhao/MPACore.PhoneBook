﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MPACore.PhoneBook.PhoneBooks.Persons;
using MPACore.PhoneBook.PhoneBooks.PhoneNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MPACore.PhoneBook.PhoneBooks.PhoneNumber.Dto
{
    [AutoMapFrom(typeof(PhoneNumbers.PhoneNumber))]
    public class PhoneNumberListDto
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(PhoneBookConsts.MaxPhoneNumberLength)]
        public string Number { get; set; }
        /// <summary>
        /// 类型
        /// </summary>

        public PhoneNumberType PhoneType { get; set; }
    }
}
