using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}