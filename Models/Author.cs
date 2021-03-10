using System;
using System.Collections.Generic;

namespace EFModels.Models
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }

        public DateTime Dob { get; set; }

        public List<BookAuthors> BookAuthors { get; set; }
    }
}