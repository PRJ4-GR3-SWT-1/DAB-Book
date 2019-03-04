using System;
using System.Collections.Generic;

namespace EFModels.Models
{
    public class Book
    {
        public int Isbn { get; set; }
        public float price { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }

        public PriceOffer PriceOffer { get; set; }
        public List<BookAuthors> BookAuthors { get; set; }
        public List<Review> Reviews { get; set; }

        
    }
}