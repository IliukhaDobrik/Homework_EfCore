using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public sealed class Book
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Guid? AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }
    }
}
