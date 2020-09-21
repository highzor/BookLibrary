using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class HolderBook
    {
        [Key]
        public int Holder_HolderId { get; set; }
        public int Book_BookId { get; set; }
    }
}