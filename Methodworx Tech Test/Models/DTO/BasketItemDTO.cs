namespace Methodworx_Tech_Test.Models.DTO
{
    public class BasketItemDTO
    {
        public int BasketItemID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
