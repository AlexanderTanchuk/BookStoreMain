using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Implementation.Dtos
{
    public class BookDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<AuthorDto> Authors { get; set; }
        public GenreDto Genre { get; set; }
        public decimal Price { get; set; }
        public int TotalAmount { get; set; }
    }
}
