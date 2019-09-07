using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<BookAuthor> BookAuthors { get; set; }

        /*public ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }*/

    }
}
