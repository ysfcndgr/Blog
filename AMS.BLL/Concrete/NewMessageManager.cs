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
    public class NewMessageManager : INewMessageService
    {
        INewMessageDal _newMessageService;
        public NewMessageManager(INewMessageDal newMessageService)
        {
            _newMessageService = newMessageService;
        }
        public void Add(NewMessage entity)
        {
            _newMessageService.Add(entity);
        }

        public void Delete(NewMessage entity)
        {
            _newMessageService.Delete(entity);
        }

        public List<NewMessage> GetAll()
        {
            return _newMessageService.GetAll();
        }

        public List<NewMessage> GetAll(int id)
        {
            return _newMessageService.GetAll(id);
        }

        public NewMessage GetById(int id)
        {
            return _newMessageService.GetById(id);
        }

        public void Update(NewMessage entity)
        {
            _newMessageService.Update(entity);
        }
    }
}
