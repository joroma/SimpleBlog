﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.Core;
using SimpleBlog.Models;
using Microsoft.Practices.Unity;


namespace SimpleBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        
           


        public BlogController (IBlogRepository blogRepository )
        {
            //BlogRepository blogRepository = new BlogRepository();
            
            _blogRepository = blogRepository;
        }
        
        public ViewResult Posts(int p = 1)
        {
            // pick latest 10 posts
            var viewModel = new ListViewModel(_blogRepository, p);

            ViewBag.Title = "Latest Posts";

            return View("List", viewModel);
        }

        public ViewResult Category(string category, int p = 1)
        {
            var viewModel = new ListViewModel(_blogRepository, category, "category", p);

            if (viewModel.Category == null)
                throw new HttpException(404, "Category not found");

            ViewBag.Title = String.Format(@"Latest posts on category ""{0}""",
                viewModel.Category.Name);

            return View("List", viewModel);
        }

        public ViewResult Tag(string tag, int p = 1)
        {
            var viewModel = new ListViewModel(_blogRepository, tag, "Tag", p);

            if (viewModel.Tag == null)
                throw new HttpException(404, "Tag not found");

            ViewBag.Title = String.Format(@"Latest posts tagged on ""{0}""", viewModel.Tag.Name);

            return View("List", viewModel);

        }
    }
}