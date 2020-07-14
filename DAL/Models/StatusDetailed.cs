using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class StatusDetailed
    {
        public StatusDetailed()
        {
            Calamity = new HashSet<Calamity>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Calamity> Calamity { get; set; }
    }
}
