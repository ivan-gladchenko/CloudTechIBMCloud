using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models.Lab7
{
    public class Order : AbstractModel
    {
        [ForeignKey("Customer")]
        public long CustomerId { get; set; }

        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public short Paid { get; set; }
        public short Executed { get; set; }
    }
}