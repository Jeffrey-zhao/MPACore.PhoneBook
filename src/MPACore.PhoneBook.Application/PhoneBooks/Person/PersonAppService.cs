using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using MPACore.PhoneBook.PhoneBooks.Person.Dto;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MPACore.PhoneBook.PhoneBooks.Person
{
    public class PersonAppService : PhoneBookAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Persons.Person> _personRepository;

        public PersonAppService(IRepository<Persons.Person> personRepository)
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
            var query = _personRepository.GetAllIncluding(a => a.PhoneNumbers);
            var personCount = await query.CountAsync();
            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = ObjectMapper.Map<List<PersonListDto>>(persons);  //persons.MapTo<List<PersonListDto>>();
            return new PagedResultDto<PersonListDto>(personCount, dtos);
        }

        public async Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input)
        {
            var person = await _personRepository.GetAllIncluding(a => a.PhoneNumbers).FirstOrDefaultAsync(a => a.Id == input.Id.Value);
            return ObjectMapper.Map<PersonListDto>(person);
        }

        protected async Task UpdatePersonAsync(PersonEditDto input)
        {
            var person = await _personRepository.GetAsync(input.Id.Value);
            await _personRepository.UpdateAsync(ObjectMapper.Map<PersonEditDto, Persons.Person>(input, person));
        }

        protected async Task CreatePersonAsync(PersonEditDto input)
        {
            var entity = ObjectMapper.Map<Persons.Person>(input);

            await _personRepository.InsertAsync(entity);
        }

        public async Task<GetPersonForEditOutput> GetPersonForEditAsync(NullableIdDto input)
        {
            var output = new GetPersonForEditOutput();
            PersonEditDto personEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _personRepository.GetAllIncluding(x=>x.PhoneNumbers).FirstOrDefaultAsync(x=>x.Id== input.Id.Value);
                personEditDto = ObjectMapper.Map<PersonEditDto>(entity);
            }
            else
            {
                personEditDto = new PersonEditDto();
            }

            output.Person = personEditDto;
            return output;
        }
    }
}
