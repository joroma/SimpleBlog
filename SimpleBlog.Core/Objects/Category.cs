﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Core.Objects
{
    public class Category
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string UrlSlug { get; set; }
        public virtual string  Description { get; set; }
        public virtual IList<Post> Posts { get; set; }
    }
}
