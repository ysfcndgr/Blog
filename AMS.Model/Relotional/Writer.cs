using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.Relotional
{
    public class Writer
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string? WriterName { get; set; }
        public string? WriterAbout { get; set; }
        public string? WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }
        #endregion Properties

        #region Relation
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<NewMessage> WriterSender { get; set; }
        public virtual ICollection<NewMessage> WriterReceiver { get; set; }
        #endregion Relation

        [NotMapped]
        public IFormFile Upload { get; set; }
    }
}
