using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleBlog.Core;
using SimpleBlog.Core.Objects;


namespace SimpleBlog.Models
{
    public class WidgetViewModel
    {
        public WidgetViewModel(IBlogRepository blogRepository)
        {
            Categories = blogRepository.Categories();
        }

        public IList<Category> Categories { get; private set; }
    }
}