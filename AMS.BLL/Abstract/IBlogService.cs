using AMS.Model.Relotional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.BLL.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        public List<Blog> GetAll(int id);
        public List<Blog> GetAllForBlogListByWriter(int id);
    }
}
