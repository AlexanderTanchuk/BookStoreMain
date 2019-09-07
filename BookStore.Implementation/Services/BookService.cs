using BookStore.Implementation.Dtos;
using BookStore.Implementation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Http.Results;


namespace BookStore.Implementation.Services
{
    public class BookService : IBookService
    {
        private BookStoreDbContext _context;

        public BookService(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<BookDetailedDto> ListDetailed()
        {
            //return _context.Books.Include(c => c.Genre).Include(c => c.BookAuthors).ToList();
            return _context.Books.Select(b => new BookDetailedDto
            {
                Id = b.Id,
                Name = b.Name,
                Authors = b.BookAuthors.Select(ba => new AuthorDto { Id = ba.AuthorId, Name = ba.Author.Name }).ToList(),
                Genre = new GenreDto { Id = b.Genre.Id, Name = b.Genre.Name },
                Price = b.Price,
                TotalAmount = b.TotalAmount
            }).ToList();
        }


        public BookDetailedDto GetDetailed(int id)
        {
            /*if (_context.Books.SingleOrDefault(c => c.Id == id) == null)
                return new NotFoundResult();*/
            //var test = _context.Books.Include(c => c.BookAuthors).ThenInclude(c => c.Author).SingleOrDefault(c => c.Id == id);
            //return _context.Books.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            return _context.Books.Where(o => o.Id == id).Select(b => new BookDetailedDto
            {
                Id = b.Id,
                Name = b.Name,
                Authors = b.BookAuthors.Select(ba => new AuthorDto { Id = ba.AuthorId, Name = ba.Author.Name }).ToList(),
                Genre = new GenreDto { Id = b.Genre.Id, Name = b.Genre.Name },
                Price = b.Price,
                TotalAmount = b.TotalAmount
            }).FirstOrDefault();
        }

        public int Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book.Id;
        }
        public int Update(int id, Book book)
        {
            var bookInDb = _context.Books.SingleOrDefault(c => c.Id == id);
            if (bookInDb == null)
                throw new InvalidOperationException($"Book with id ={id} was not found");
            bookInDb.Name = book.Name;
            bookInDb.Price = book.Price;
            bookInDb.TotalAmount = book.TotalAmount;
            bookInDb.GenreId = book.GenreId;
            bookInDb.BookAuthors = book.BookAuthors;
            _context.SaveChanges();
            return id;
        }

        public void Delete(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(c => c.Id == id);
            if (bookInDb == null)
                throw new InvalidOperationException($"Book with id ={id} was not found");
            _context.Books.Remove(bookInDb);
            _context.SaveChanges();
        }

        public void AddAuthor (int bookId, int authorId)
        {
            var bookInDb = _context.Books.SingleOrDefault(c => c.Id == bookId);
            var authorInDb = _context.Authors.SingleOrDefault(c => c.Id == authorId);
            /*if (_context.Authors.SingleOrDefault(c => c.Name == author.Name) == null)
            {
                _context.Authors.Add(author);
                _context.SaveChanges();
            }*/
            if (bookInDb.BookAuthors == null)
            {
                bookInDb.BookAuthors = new List<BookAuthor>
                {
                    new BookAuthor
                    {
                        Book = bookInDb,
                        Author = authorInDb
                    }
                };
            }
            else
            {
                bookInDb.BookAuthors.Add(new BookAuthor
                {
                    Author = authorInDb,
                    Book = bookInDb
                });
            }
            _context.SaveChanges();
            //_context.Add(new BookAuthor { Book = bookInDb, Author = author });
        }
    }
}
