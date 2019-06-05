using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_implementation.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BookId { get; set; }
        public Book Book { get; set; }
    }
}
