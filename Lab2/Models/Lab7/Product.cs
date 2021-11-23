using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models.Lab7
{
    public class Product : AbstractModel
    {
        public string ProdName { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        [ForeignKey("Supplier")]
        public long Supplier_Id { get; set; }

        public Supplier Supplier { get; set; }
    }
}