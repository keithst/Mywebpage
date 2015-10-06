using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication4.Models
{
    public class BlogPost
    {
       public BlogPost()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public System.DateTimeOffset Created { get; set; }
        public Nullable<System.DateTimeOffset> Updated { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        public string MediaURL { get; set; }
        public bool Published { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}