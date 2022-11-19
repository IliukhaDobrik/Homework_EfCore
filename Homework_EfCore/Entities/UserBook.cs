using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public sealed class UserBook
    {
        public Guid UserBookId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? AuthorId { get; set; }
        public ICollection<Book> Books { get; set;}
        public ICollection<User> Users { get;}
    }
}
