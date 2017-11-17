using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Tag
    {
        public Tag() 
        {
            this.PostTags = new List<PostTag>();
        }        

        public int ID { get; set; }
        public string Title { get; set; }

        public virtual List<PostTag> PostTags { get; set; }
    }
}