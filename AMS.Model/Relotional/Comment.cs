using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.Relotional
{
    public class Comment
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string CommentUserName { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public int BlogScore { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }
        #endregion Properties

        #region Relational
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        #endregion Relational
    }
}
