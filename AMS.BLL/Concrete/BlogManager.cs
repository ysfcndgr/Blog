using AMS.BLL.Abstract;
using AMS.DAL.Abstract.EfCore;
using AMS.Model.Relotional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AMS.BLL.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void Add(Blog entity)
        {
            _blogDal.Add(entity);
        }

        public void Delete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetAll(int id)
        {
            return _blogDal.GetAll(id);
        }

        public List<Blog> GetAllForBlogListByWriter(int id)
        {
            return _blogDal.GetAllForBlogListByWriter(id);
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public void Update(Blog entity)
        {
            _blogDal.Update(entity);
        }
    }
}
