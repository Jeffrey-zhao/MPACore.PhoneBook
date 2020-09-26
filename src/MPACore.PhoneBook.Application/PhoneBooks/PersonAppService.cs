using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using MPACore.PhoneBook.PhoneBooks.Dto;
using MPACore.PhoneBook.PhoneBooks.Persons;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace MPACore.PhoneBook.PhoneBooks
{
    public class PersonAppService : PhoneBookAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task CreateOrUpdatePersonAsync(PersonEditDto input)
        {
            //update
            if (input.Id.HasValue)
            {
                await UpdatePersonAsync(input);
            }
            //create
            else
            {
                await CreatePersonAsync(input);

            }
        }

        public async Task DeletePersonAsync(EntityDto input)
        {
            var person = _personRepository.GetAsync(input.Id);
            if (person == null)
            {
                throw new UserFriendlyException("该联系人已经不存在了");
            }
            await _personRepository.DeleteAsync(input.Id);
        }

        public async Task<PagedResultDto<PersonListDto>> GetPagedPersonAysnc(GetPersonInput input)
        {
            var query = _personRepository.GetAll();
            var personCount = await query.CountAsync();
            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = ObjectMapper.Map<List<PersonListDto>>(persons);  //persons.MapTo<List<PersonListDto>>();
            return new PagedResultDto<PersonListDto>(personCount, dtos);
        }

        public async Task<PersonListDto> GetPersonByIdAysnc(NullableIdDto input)
        {
            var person = await _personRepository.GetAsync(input.Id.Value);
            return ObjectMapper.Map<PersonListDto>(person);
        }

        protected async Task UpdatePersonAsync(PersonEditDto input)
        {
            var person = await _personRepository.GetAsync(input.Id.Value);
            await _personRepository.UpdateAsync(ObjectMapper.Map<PersonEditDto, Person>(input, person));
        }

        protected async Task CreatePersonAsync(PersonEditDto input)
        {
            await _personRepository.InsertAsync(ObjectMapper.Map<Person>(input));
        }
    }
}
