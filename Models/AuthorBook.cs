using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2021GPD.Models
{
    class AuthorBook
    {
        public int AuthorId { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public virtual Author Author { get; set; }
    }
}
