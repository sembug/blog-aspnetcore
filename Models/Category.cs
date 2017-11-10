using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public virtual List<Post> Posts { get; set; } 
    }
}