using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MPACore.PhoneBook.Controllers;
using MPACore.PhoneBook.PhoneBooks;
using MPACore.PhoneBook.PhoneBooks.Dto;

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
