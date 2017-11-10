using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Post
    {
        public Post()
        {
            this.Publish = DateTime.Now;
            this.PostTags = new List<PostTag>();
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Author { get; set; }
        public DateTime Publish { get; set; }
        public string Body { get; set; }

        public int  CategoryId { get; set; }

        public List<PostTag> PostTags { get; set; }
        public virtual Category Category { get; set; } 
    }
}
