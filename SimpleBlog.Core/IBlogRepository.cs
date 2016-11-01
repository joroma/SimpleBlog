using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBlog.Core.Objects;

namespace SimpleBlog.Core
{
    public interface IBlogRepository
    {
        IList<Post> Posts(int PageNo, int PageSize);
        int TotalPosts();
    }
}
