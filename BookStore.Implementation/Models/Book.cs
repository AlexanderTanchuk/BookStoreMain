using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<BookAuthor> BookAuthors { get; set; }
        public Genre Genre { get; set; }

        public byte GenreId { get; set; }
        //public IList<Genre> Genres { get; set; }
        /*public Book()
        {
            Genres = new List<Genre>();
        }*/

        public decimal Price { get; set; }

        public int TotalAmount { get; set; }
    }
}
