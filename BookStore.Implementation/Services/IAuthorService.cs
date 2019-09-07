using System.Collections.Generic;
using BookStore.Implementation.Dtos;
using BookStore.Implementation.Models;

namespace BookStore.Implementation.Services
{
    public interface IAuthorService
    {
        int Create(Author author);
        void Delete(int id);
        AuthorDetailedDto GetDetailed(int id);
        List<AuthorDetailedDto> ListDetailed();
        int Update(int id, Author author);
    }
}