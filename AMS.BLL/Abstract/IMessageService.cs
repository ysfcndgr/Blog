using AMS.Model.Relotional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.BLL.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        public List<Message> GetAll(string id);
    }
}
