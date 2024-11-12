﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Libreria_CAAR.Data.Services;
using Libreria_CAAR.Data.ViewModels;

namespace Libreria_CAAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        public PublishersService _publishersService;
        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }



        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }



        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPubliserData(int id)
        {
            var _response = _publishersService.GetPublisherData(id);
            return Ok(_response);
        }
    }
}
