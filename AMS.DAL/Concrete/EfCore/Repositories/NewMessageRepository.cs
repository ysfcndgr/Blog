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
    public class NewMessageRepository : GenericRepository<NewMessage>, INewMessageDal
    {
        public List<NewMessage> GetAll(int id)
        {
            using(Context c = new Context())
            {
                return c.NewMessages.Include(x=>x.SenderUser).Where(x => x.ReceiverId==id).ToList();
            }
        }
        public NewMessage GetById(int id)
        {
            using (Context c = new Context())
            {
                return c.NewMessages.Include(x => x.SenderUser).Where(x => x.Id == id).FirstOrDefault();
            }
        }
    }
}
