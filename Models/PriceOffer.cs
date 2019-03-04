namespace EFModels.Models
{
    public class PriceOffer
    {
        public int Id { get; set; }
        public float NewPrice { get; set; }
        public string PromotionText { get; set; }

        public int BookIsbn { get; set; }
        public Book Book { get; set; }
    }
}