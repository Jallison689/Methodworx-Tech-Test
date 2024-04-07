using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Methodworx_Tech_Test.Models.Generated
{
    public class BasketItem
    {
        [Key]
        public int BasketItemID { get; set; }
        [ForeignKey("ProductID")]
        public int ProductId { get; set; }
        [ForeignKey("BasketID")]
        public int BasketID { get; set; }
        public int BasketItemQuantity { get; set; }
    }
}
