using AMS.Model.Relotional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.BLL.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        public List<Comment> GetAll(int id);
    }
}
