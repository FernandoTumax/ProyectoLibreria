using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2021GPD.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime Publication { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public virtual List<Author> Authors { get; set; }
        public override string ToString()
        {
            return $"{Title} - {Publication}";
        }
    }
}
