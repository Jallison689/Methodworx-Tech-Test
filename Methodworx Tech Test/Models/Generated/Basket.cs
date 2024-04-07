using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Methodworx_Tech_Test.Models.Generated
{
    public class Basket
    {
        [Key]
        public int BasketID { get; set; }
        [ForeignKey("BasketStatusID")]
        public int BasketStatusID { get; set; }
    }
}
