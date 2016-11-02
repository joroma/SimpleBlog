using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SimpleBlog.Core.Mappings
{
    public class MockInitializer : DropCreateDatabaseAlways<SimpleBlogContext>
    {
        protected override void Seed(SimpleBlogContext context)
        {
            base.Seed(context);
        }
    }
}
