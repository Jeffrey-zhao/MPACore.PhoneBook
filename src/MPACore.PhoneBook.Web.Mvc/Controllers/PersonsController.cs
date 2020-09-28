using Microsoft.AspNetCore.Mvc;
using MPACore.PhoneBook.Controllers;
using MPACore.PhoneBook.PhoneBooks.Person;
using MPACore.PhoneBook.PhoneBooks.Person.Dto;
using System.Threading.Tasks;

namespace MPACore.PhoneBook.Web.Controllers
{
    public class PersonsController : PhoneBookControllerBase
    {
        private readonly IPersonAppService _personAppService;
        public PersonsController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }
        public async Task<IActionResult> Index(GetPersonInput input)
        {
           var pagedPersonDtos= await _personAppService.GetPagedPersonAysnc(input);
            return View(pagedPersonDtos);
        }
    }
}
