using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;
using Lab2.Models.Lab7;
using Microsoft.EntityFrameworkCore;

namespace Lab2
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {
        }
        public DbSet<Note> Notes { get; set; }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Note>(entity => entity.ToTable(name: "Notes"));
            builder.Entity<Customer>(entity => entity.ToTable(name: "Customer"));
            builder.Entity<Order>(entity => entity.ToTable(name: "Order"));
            builder.Entity<OrderItem>(entity => entity.ToTable(name: "OrderItem"));
            builder.Entity<Product>(entity => entity.ToTable(name: "Product"));
            builder.Entity<Supplier>(entity => entity.ToTable(name: "Supplier"));
            builder.ApplyConfiguration(new NotesConfiguration());
        }

        public void GenerateData()
        {
            var supplier = new Supplier
            {
                SupFax = "fax",
                SupName = "supplier",
                SupTown = "kyiv"
            };
            Supplier.Add(supplier);
            var product1 = new Product
            {
                Price = 20.5,
                ProdName = "toaster",
                Supplier = supplier,
                Stock = 1,
                Unit = "idk"
            };
            var product2 = new Product
            {
                Price = 300.5,
                ProdName = "refrigerator",
                Supplier = supplier,
                Stock = 1,
                Unit = "idk"
            };
            var product3 = new Product
            {
                Price = 200.5,
                ProdName = "washing machine",
                Supplier = supplier,
                Stock = 1,
                Unit = "idk"
            };
            Product.AddRange(new List<Product>{product1, product2, product3});
            var customer1 = new Customer
            {
                CustTown = "kyiv",
                CustName = "Ivan",
                CustFax = "123"
            };
            var customer2 = new Customer
            {
                CustTown = "lviv",
                CustName = "Oleg",
                CustFax = "123"
            };

            Customer.AddRange(new List<Customer> {customer1, customer2});
            var order1 = new Order
            {
                Customer = customer1,
                Date = DateTime.Now,
                Executed = 1,
                Paid = 1
            };
            var order2 = new Order
            {
                Customer = customer1,
                Date = DateTime.Now,
                Executed = 1,
                Paid = 1
            };
            var order3 = new Order
            {
                Customer = customer2,
                Date = DateTime.Now,
                Executed = 1,
                Paid = 1
            };
            Order.AddRange(new List<Order>{order1, order2, order3});
            var orderItem1 = new OrderItem
            {
                Product = product1,
                Quantity = 2,
                Order = order1
            };
            var orderItem2 = new OrderItem
            {
                Product = product2,
                Quantity = 2,
                Order = order2
            };
            var orderItem3 = new OrderItem
            {
                Product = product3,
                Quantity = 2,
                Order = order3
            };
            OrderItem.AddRange(new List<OrderItem>{orderItem1, orderItem2, orderItem3});
            SaveChanges();
        }

        public void LazyLoad()
        {
            Product.Load();
            Order.Load();
            OrderItem.Load();
            Customer.Load();
            Supplier.Load();
        }
    }
}
