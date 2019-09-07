using System.Collections.Generic;
using BookStore.Implementation.Dtos;
using BookStore.Implementation.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Implementation.Services
{
    public interface IBookService
    {
        void Delete(int id);
        List<BookDetailedDto> ListDetailed();
        BookDetailedDto GetDetailed(int id);
        int Create(Book book);
        int Update(int id, Book book);
        void AddAuthor(int bookId, int authorId);
    }
}