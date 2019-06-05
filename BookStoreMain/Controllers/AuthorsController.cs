using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore_implementation.Models;

namespace BookStoreMain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private List<Author> authors;
        public AuthorsController()
        {
            authors = new List<Author>{
                new Author
                {
                    Id = 1,
                    Name = "Puskkin",
                    
                },
                new Author
                {
                    Id = 2,
                    Name = "Gogoljevich",

                },
                new Author
                {
                    Id = 3,
                    Name = "Boiboi",

                },
                };
        }

        [HttpGet/*("[action]")*/]
        public List<Author> Return()
        {
            return authors;
        }

        [HttpGet("{id}")/*("[action]")*/]
        public Author Return(int id)
        {
            return authors.SingleOrDefault(c => c.Id == id);
        }

        [HttpPost]
        public ActionResult Create()
        {
            var length = authors.Count + 1;

            authors.Add(new Author
            {
                Id = length,
                Name = "Author No" + length,
            });
            return Content("Added Author id=" + length);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            /*var book = books.SingleOrDefault(c => c.Id == id);
            if (book == null)
                return NotFound();
            books.Remove(book);*/
            return Content("Deleted id=" + id);
        }
    }
}