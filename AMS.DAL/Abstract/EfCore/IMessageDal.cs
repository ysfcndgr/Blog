using AMS.Model.Relotional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DAL.Abstract.EfCore
{
    public interface IMessageDal:IGenericDal<Message>
    {
        public List<Message> GetAll(string id);
    }
}
