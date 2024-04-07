using System.ComponentModel.DataAnnotations;

namespace Methodworx_Tech_Test.Models.Generated
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductCount { get; set; }
    }
}
