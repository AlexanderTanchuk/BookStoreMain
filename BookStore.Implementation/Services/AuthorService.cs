using BookStore.Implementation.Dtos;
using BookStore.Implementation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Implementation.Services
{
    public class AuthorService : IAuthorService
    {
        private BookStoreDbContext _context;

        public AuthorService(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<AuthorDetailedDto> ListDetailed()
        {
            //var r = _context.Authors.ToList();
            return _context.Authors.Select(a => new AuthorDetailedDto
            {
                Id = a.Id,
                Name = a.Name,
                Books = a.BookAuthors.Select(ba => new BookDto { Id = ba.BookId, Name = ba.Book.Name }).ToList()
            }).ToList();
        }


        public AuthorDetailedDto GetDetailed(int id)
        {
            /*if (_context.Books.SingleOrDefault(c => c.Id == id) == null)
                return new NotFoundResult();*/
            /*var test = _context.Authors.Include(c => c.BookAuthors).ThenInclude(it => it.Book).SingleOrDefault(c => c.Id == id);
            AuthorDto authorDto = new AuthorDto();
            authorDto.Name = test.Name;
            test.BookAuthors.
            authorDto.Books = test.BookAuthors.ToList()*/
            //var author = _context.Authors.Include(c => c.BookAuthors).ThenInclude(it => it.Book).SingleOrDefault(c => c.Id == id);
            return _context.Authors.Where(c => c.Id == id).Select(a => new AuthorDetailedDto {
                Id = a.Id,
                Name = a.Name,
                Books = a.BookAuthors.Select(ba => new BookDto { Id = ba.BookId, Name = ba.Book.Name }).ToList()
            }).FirstOrDefault();
        }

        public int Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author.Id;
        }
        public int Update(int id, Author author)
        {
            var authorInDb = _context.Authors.SingleOrDefault(c => c.Id == id);
            if (authorInDb == null)
                throw new InvalidOperationException($"Author with id ={id} was not found");

            authorInDb.Name = author.Name;
            authorInDb.BookAuthors = author.BookAuthors;
            _context.SaveChanges();
            return id;
        }

        public void Delete(int id)
        {
            var authorInDb = _context.Authors.SingleOrDefault(c => c.Id == id);
            if (authorInDb == null)
                throw new InvalidOperationException($"Author with id ={id} was not found");
            _context.Authors.Remove(authorInDb);
            _context.SaveChanges();
        }
    }
}
