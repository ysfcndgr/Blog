using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.Relotional
{
    public class Match
    {
        [Key]
        public int Id { get; set; }
        public int? HomeTeamId { get; set; }
        public int? GuestTeamId { get; set; }
        public DateTime DateTime { get; set; }
        public string Stadium { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team GuestTeam { get; set; }
    }
}
