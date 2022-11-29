using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Dtos
{
    public sealed class BookRequestDto
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public Guid? AuthorId { get; set; }
    }
}
