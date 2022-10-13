using AMS.Model.Relotional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DAL.Abstract.EfCore
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        public List<Blog> GetAll(int id);
        public List<Blog> GetAll();
        public List<Blog> GetAllForBlogListByWriter(int id);

    }
}
