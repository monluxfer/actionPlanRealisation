using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Book : Literature
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
