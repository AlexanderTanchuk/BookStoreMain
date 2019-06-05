using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_implementation.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public Book()
        {
            Authors = new List<Author>();
            Genres = new List<Genre>();
        }

        public decimal Price { get; set; }

        public int TotalAmount { get; set; }
    }
}
