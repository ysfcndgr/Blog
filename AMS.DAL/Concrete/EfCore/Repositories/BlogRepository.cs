using AMS.DAL.Abstract.EfCore;
using AMS.Model.Relotional;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DAL.Concrete.EfCore.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetAll()
        {
            using (var context = new Context())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }
        public List<Blog> GetAll(int id)
        {
            using (var context = new Context())
            {
                return context.Blogs.Where(x=>x.WriterId==id).OrderByDescending(y=>y.BlogCreateDate).Take(3).ToList();
            }
        }
        public List<Blog> GetAllForBlogListByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Blogs.Where(x => x.WriterId == id).Include(x=>x.Category).OrderByDescending(y => y.BlogCreateDate).ToList();
            }
        }
        //public List<Blog> GetLastFiveBlog()
        //{
        //    using (var context = new Context())
        //    {
        //        return context.Blogs.Include(x => x.Category).TakeLast(5).ToList();
        //    }
        //}
    }
}
