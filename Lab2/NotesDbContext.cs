using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {
        }
        public DbSet<Note> Notes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Note>(entity => entity.ToTable(name: "Notes"));
            builder.ApplyConfiguration(new NotesConfiguration());
        }
    }
}
