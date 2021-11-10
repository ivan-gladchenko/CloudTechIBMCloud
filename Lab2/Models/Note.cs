using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class Note
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string Theme { get; set; }
        public DateTime Date { get; set; }
    }
}
