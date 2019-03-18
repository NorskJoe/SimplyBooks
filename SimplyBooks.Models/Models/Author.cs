using System;
using System.Collections.Generic;
using System.Text;

namespace SimplyBooks.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nationality Nationality { get; set; }
    }
}
