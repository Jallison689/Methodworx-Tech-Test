using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Methodworx_Tech_Test.Models.Generated
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [ForeignKey("BasketID")]
        public int BasketID { get; set; }
        [ForeignKey("OrderStatusID")]
        public int OrderStatusID { get; set; }
        public string OrderEmail { get; set; }
        public int CardNumber { get; set; }
        public int CVVNumber { get; set; }
        public DateTime CardExpirationDate { get; set; }
    }
}
