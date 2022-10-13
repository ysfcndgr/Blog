 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.Relotional
{
    public class Blog
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string? BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string? BlogThumbnailImage { get; set; }
        public string? BlogImage{ get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        #endregion Properties

        #region Relational
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        #endregion Relational
    }
}
