using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthorService.Models
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
