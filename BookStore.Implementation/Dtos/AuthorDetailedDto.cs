using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Implementation.Dtos
{
    public class AuthorDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<BookDto> Books { get; set; }
    }
}
