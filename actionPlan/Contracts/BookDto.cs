﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class BookDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string? Title { get; set; }
    }
}
