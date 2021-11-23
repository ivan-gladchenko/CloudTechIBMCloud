using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Lab2.Models.Lab7
{
    public class Customer: AbstractModel
    {
        public string CustName { get; set; }
        public string CustFax { get; set; }
        public string CustTown { get; set; }
        public List<Order> Orders { get; set; }
    }
}