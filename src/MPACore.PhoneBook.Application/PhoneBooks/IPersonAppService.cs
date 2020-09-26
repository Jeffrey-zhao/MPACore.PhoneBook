using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MPACore.PhoneBook.PhoneBooks.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPACore.PhoneBook.PhoneBooks
{
    public interface IPersonAppService : IApplicationService
    {
        /// <summary>
        /// 获取分页联系人信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PersonListDto>> GetPagedPersonAysnc(GetPersonInput input);
        /// <summary>
        /// 根据Id获取联系人信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PersonListDto> GetPersonByIdAysnc(NullableIdDto input);
        /// <summary>
        /// 新增或更改联系人
        /// </summary>
        /// <returns></returns>
        Task CreateOrUpdatePersonAsync(PersonEditDto input);

        /// <summary>
        /// 删除联系人信息
        /// </summary>
        /// <returns></returns>
        Task DeletePersonAsync(EntityDto input);
    }
}
