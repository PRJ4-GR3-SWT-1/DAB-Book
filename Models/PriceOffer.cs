namespace EFModels.Models
{
    public class PriceOffer : Book
    {
        public float NewPrice { get; set; }
        public string PromotionText { get; set; }
    }
}