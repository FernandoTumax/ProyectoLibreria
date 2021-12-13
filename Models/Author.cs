using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2021GPD.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
