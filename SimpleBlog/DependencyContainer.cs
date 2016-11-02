using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using SimpleBlog.Core;

namespace SimpleBlog
{
    public class DependencyContainer
    {
        public static void RegisterElements(IUnityContainer container)
        {
            //BlogRepository blogRepository = new BlogRepository();
            //container.RegisterInstance(blogRepository);
            //container.RegisterType<IBlogRepository, BlogRepository>();
        }
    }
}