using System;
using System.Collections.Generic;

namespace EFModels.Models
{
    public class BookAuthors
    {
        public int BookAuthorsId { get; set; }
        public int BookIsbn { get; set; }
        public Book Book { get; set; }

        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public Author Author { get; set; }
        

        
    }
}