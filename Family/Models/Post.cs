using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Family.Models
{
    public class Post
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ApplicationUser Author { get; set; }
        public DateTime PostTime { get; set; }
    }
}