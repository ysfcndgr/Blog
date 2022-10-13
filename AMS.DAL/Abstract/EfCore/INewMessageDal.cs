using AMS.Model.Relotional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DAL.Abstract.EfCore
{
    public interface INewMessageDal:IGenericDal<NewMessage>
    {
        public List<NewMessage> GetAll(int id);
    }
}
