using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.Relotional
{
    public class Category
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }
        #endregion Properties

        #region Relational
        public virtual ICollection<Blog> Blogs { get; set; }
        #endregion Relational
    }
}
