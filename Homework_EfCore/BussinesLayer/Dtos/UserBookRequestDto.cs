using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Dtos
{
    public sealed class UserBookRequestDto
    {
        public Guid? UserId { get; set; }
        public Guid? BookId { get; set; }
    }
}
