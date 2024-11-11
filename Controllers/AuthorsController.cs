﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Libreria_CAAR.Data.Services;
using Libreria_CAAR.Data.ViewModels;

namespace Libreria_CAAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public AuthorsService  _authorsService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }



        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }
    }
}
