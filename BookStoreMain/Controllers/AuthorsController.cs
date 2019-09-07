using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.Implementation.Models;
using BookStore.Implementation.Services;

namespace BookStoreMain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private List<Author> authors;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public JsonResult Return()
        {
            return new JsonResult(_authorService.ListDetailed());
        }

        [HttpGet("{id}")]
        public JsonResult Return(int id)
        {
            return new JsonResult(_authorService.GetDetailed(id));
        }

        [HttpPost]
        public JsonResult Create(Author author)
        {
            
            return new JsonResult(_authorService.Create(author)); ;
        }

        [HttpPut]
        public JsonResult Update(int id, Author author)
        {
            return new JsonResult(_authorService.Update(id, author));
        }
        
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _authorService.Delete(id);
            return new OkResult();
        }

        [HttpPost("[action]")]
        public JsonResult TestCreate()
        {
            var authorTest = new Author
            {
                Name = "TestBook Writer"
            };
            return new JsonResult(_authorService.Create(authorTest));
        }
    }
}