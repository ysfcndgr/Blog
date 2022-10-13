using AMS.DAL.Abstract.EfCore;
using AMS.Model.Relotional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DAL.Concrete.EfCore.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageDal
    {
        public List<Message> GetAll(string id)
        {
            using(Context c = new Context())
            {
                return c.Messages.Where(x => x.Receiver == id).ToList();
            }
        }
    }
}
