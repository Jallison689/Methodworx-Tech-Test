using System.ComponentModel.DataAnnotations;

namespace Methodworx_Tech_Test.Models.Generated
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusID { get; set; }
        public string OrderStatusName { get; set; }
    }
}
