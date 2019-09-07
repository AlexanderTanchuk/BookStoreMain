using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.Implementation.Models;
using BookStore.Implementation.Services;
using BookStore.Implementation;

namespace BookStoreMain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private List<Book> books;
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public JsonResult Return()
        {
            return new JsonResult(_bookService.ListDetailed());
        }

        [HttpGet("{id}")]
        public JsonResult Return(int id)
        {
            //not found
            return new JsonResult(_bookService.GetDetailed(id));
        }

        [HttpPost]
        public JsonResult Create(Book book)
        {
            return new JsonResult(_bookService.Create(book));
        }

        [HttpPut]
        public JsonResult Update(int id,Book book)
        {
            return new JsonResult(_bookService.Update(id,book));
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return new OkResult();
        }

        [HttpPost("[action]")]
        public JsonResult TestCreate()
        {
            var bookTest = new Book
            {
                Name = "TestBook",
                Price = 29.99m,
                TotalAmount = 1,
                GenreId = 1
            };
            return new JsonResult(_bookService.Create(bookTest));
        }

        [HttpPost("[action]")]
        public ActionResult BookAuthorCreate(int bookId, int authorId)
        {
            _bookService.AddAuthor(bookId, authorId);
            return new OkResult();
        }
    }
}