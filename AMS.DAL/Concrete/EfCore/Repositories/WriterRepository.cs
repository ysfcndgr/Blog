using AMS.DAL.Abstract.EfCore;
using AMS.Model.Relotional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DAL.Concrete.EfCore.Repositories
{
    public class WriterRepository : GenericRepository<Writer>, IWriterDal
    {
        public Writer? Login(string mail, string password)
        {
            using (Context context = new Context())
            {
                var model = context.Writer.Where(x => x.WriterMail == mail && x.WriterPassword == password).FirstOrDefault();
                return model;
            }
        }
    }
}
