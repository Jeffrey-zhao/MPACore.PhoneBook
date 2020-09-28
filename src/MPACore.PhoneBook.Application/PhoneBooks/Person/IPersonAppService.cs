using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MPACore.PhoneBook.PhoneBooks.Person.Dto;
using System.Threading.Tasks;

namespace MPACore.PhoneBook.PhoneBooks.Person
{
    public interface IPersonAppService : IApplicationService
    {
        /// <summary>
        /// 获取分页联系人信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<Person.Dto.PersonListDto>> GetPagedPersonAysnc(GetPersonInput input);
        /// <summary>
        /// 根据Id获取联系人信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input);

        /// <summary>
        /// 根据Id获取联系人信息进行编辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetPersonForEditOutput> GetPersonForEditAsync(NullableIdDto input);
        
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
