using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public List<Holder> Holder { get; set; }
    }
}