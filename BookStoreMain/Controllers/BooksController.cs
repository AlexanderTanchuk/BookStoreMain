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
    public class BooksController : ControllerBase
    {
        private List<Book> books;
        public BooksController()
        {
            books = new List<Book>{
                new Book
                {
                    Id = 1,
                    Name = "Shrouge:Shrek Vouge",
                },
                new Book
                {
                    Id = 2,
                    Name = "Shrek the book",

                },
                new Book
                {
                    Id = 3,
                    Name = "This is my swamp",

                }
                };
        }

        [HttpGet/*("[action]")*/]
        public List<Book> Return()
        {
            return books;
        }

        [HttpGet("{id}")/*("[action]")*/]
        public Book Return(int id)
        {
            return books.SingleOrDefault(c => c.Id == id);
        }

        [HttpPost]
        public ActionResult Create()
        {
            var length = books.Count + 1;

            books.Add(new Book
            {
                Id = length,
                Name = "Book No" + length,
            });
            return Content("Added book id=" + length);
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