using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models.Lab7
{
    public class OrderItem : AbstractModel
    {
        [ForeignKey("Product")]
        public long Product_Id { get; set; }

        public Product Product { get; set; }
        public long Quantity { get; set; }
        [ForeignKey("Order")]
        public long Order_Id { get; set; }

        public Order Order { get; set; }
    }
}