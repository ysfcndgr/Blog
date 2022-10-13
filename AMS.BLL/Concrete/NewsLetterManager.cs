using AMS.BLL.Abstract;
using AMS.DAL.Abstract.EfCore;
using AMS.Model.Relotional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.BLL.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;
        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }
        public void Add(NewsLetter entity)
        {
            _newsLetterDal.Add(entity);
        }

        public void Delete(NewsLetter entity)
        {
            _newsLetterDal.Delete(entity);
        }

        public List<NewsLetter> GetAll()
        {
            return _newsLetterDal.GetAll();
        }

        public NewsLetter GetById(int id)
        {
            return _newsLetterDal.GetById(id);
        }

        public void Update(NewsLetter entity)
        {
            _newsLetterDal.Update(entity);
        }
    }
}
